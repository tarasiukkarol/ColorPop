using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            ColorPopMechanismType mechanismType,
            int numberOfThreads)
        {
            _oldBitmap = bitmapImage;
            _allPixels = RetrievePixels(bitmapImage);
            _numberOfThreads = numberOfThreads;
            int pieceLenght = AdjustPieceLenght();
            for (int partNumber = 0; partNumber < _numberOfThreads; partNumber++)
            {
                int tempPartNumber = partNumber;
                int pieceEnd;
                if (partNumber + 1 == _numberOfThreads)
                    pieceEnd = _allPixels.Length;
                else
                    pieceEnd = pieceLenght * (tempPartNumber + 1) - 1;
                _ColorPopInterfaces.Add(MechanismFactory.Create(
                        mechanismType,
                        bitmapImage.Format.BitsPerPixel / _bitsInByte,
                        pieceLenght * tempPartNumber,
                        pieceEnd));
                _tasks.Add(new Task(() =>
                    _ColorPopInterfaces[tempPartNumber].ExecuteEffect(_allPixels)));
            }
        }

        private int AdjustPieceLenght()
        {
            int pieceLenght = _allPixels.Length / _numberOfThreads;
            while (pieceLenght % (_oldBitmap.Format.BitsPerPixel / _bitsInByte) != 0)
                pieceLenght++;
            return pieceLenght;
        }

        private float[] RetrievePixels(BitmapSource bitmapImage)
        {
            return bitmapImage.ToBmpBGRArray();
        }

        public BitmapSource ExecuteEffect(out System.TimeSpan elapsedTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Parallel.ForEach(_tasks, (task) => task.Start());
            Task.WaitAll(_tasks.ToArray());

            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;

            return _allPixels.BmpBGRArrayToImage(_oldBitmap.PixelWidth,
                _oldBitmap.PixelHeight, _oldBitmap.Format);
        }
    }
}