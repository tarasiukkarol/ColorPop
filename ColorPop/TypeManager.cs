using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ColorPop
{
    class TypeManager
    {
        private BitmapSource _oldBitmap;
        private List<ColorPopInterface> _ColorPopInterfaces = new List<ColorPopInterface>();
        private List<Task> _tasks = new List<Task>();
        private int _numberOfThreads;
        private float[] _allPixels;

        const int _bitsInByte = 8;

        private TypeManager() { }

        public TypeManager(BitmapSource bitmapImage,
            ColorPopMechanismType mechanismType, float[] chosenColor,
            int numberOfThreads)
        {
            _oldBitmap = bitmapImage;
            _allPixels = RetrievePixels(bitmapImage);
            _numberOfThreads = numberOfThreads;
            int pieceLenght = AdjustPieceLenght();

            // Creating ColorPopInterfaces and corresponding Tasks for parallel execution
            for (int partNumber = 0; partNumber < _numberOfThreads; partNumber++)
            {
                int tempPartNumber = partNumber;
                int pieceEnd;
                if (partNumber + 1 == _numberOfThreads)
                {
                    pieceEnd = _allPixels.Length;
                }
                else
                {
                    pieceEnd = pieceLenght * (tempPartNumber + 1) - 1;
                }
                _ColorPopInterfaces.Add(MechanismFactory.Create(
                        mechanismType, chosenColor,
                        bitmapImage.Format.BitsPerPixel / _bitsInByte,
                        pieceLenght * tempPartNumber,
                        pieceEnd));

                _tasks.Add(new Task(() =>_ColorPopInterfaces[tempPartNumber].ExecuteEffect(_allPixels)));
            }
        }

        private int AdjustPieceLenght()// Adjust the length of each processing piece to ensure it's divisible by pixel size
        {
            int pieceLenght = _allPixels.Length / _numberOfThreads;
            while (pieceLenght % (_oldBitmap.Format.BitsPerPixel / _bitsInByte) != 0)
            {
                pieceLenght++;
            }
            return pieceLenght;
        }

        private float[] RetrievePixels(BitmapSource bitmapImage)// Retrieve the pixel array from the BitmapSource
        {
            return bitmapImage.ToBmpBGRArray();
        }

        // Execute the color effect using multiple threads and return the resulting image
        public BitmapSource ExecuteEffect(out System.TimeSpan elapsedTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Parallel.ForEach(_tasks, (task) => task.Start());
            Task.WaitAll(_tasks.ToArray());

            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;

            // Convert processed pixels back to BitmapSource (image)
            return _allPixels.BmpBGRArrayToImage(_oldBitmap.PixelWidth, _oldBitmap.PixelHeight, _oldBitmap.Format);
        }
    }
}