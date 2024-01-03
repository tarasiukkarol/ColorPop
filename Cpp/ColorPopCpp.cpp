#include "pch.h";
#include <cmath>

void ColorPop(float* pixels, int size, float* chosenColor, float* rgb_rates, int bytes_pp, int start, int end) {
	for (int i = start; i < end && i < size; i += bytes_pp) {
		if (abs(pixels[i + 2] - chosenColor[0]) <= 20 &&
			abs(pixels[i + 1] - chosenColor[1]) <= 20 &&
			abs(pixels[i] - chosenColor[2]) <= 20)
		{
			float avg = pixels[i] * rgb_rates[0] + pixels[i + 1] * rgb_rates[1] + pixels[i + 2] * rgb_rates[2];

			pixels[i] = avg;
			pixels[i + 1] = avg;
			pixels[i + 2] = avg;
		}
	}
};

extern "C" __declspec(dllexport) void ColorPopCpp(float* pixels, int size, float* chosenColor, float* rgb_rates, int bytes_pp, int start, int end)
{
	ColorPop(pixels, size, chosenColor, rgb_rates, bytes_pp, start, end);
};