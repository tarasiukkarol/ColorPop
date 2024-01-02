#include "pch.h";

void ColorPop(float* pixels, int size, float* rgb_rates, int bytes_pp, int start, int end) {
	for (int i = start; i < end && i < size; i += bytes_pp) {
		float avg = pixels[i] * rgb_rates[0] + pixels[i + 1] * rgb_rates[1] + pixels[i + 2] * rgb_rates[2];

		pixels[i] = avg;
		pixels[i + 1] = avg;
		pixels[i + 2] = avg;
	}
};

extern "C" __declspec(dllexport) void ColorPopCpp(float* pixels, int size, float* rgb_rates, int bytes_pp, int start, int end)
{
	ColorPop(pixels, size, rgb_rates, bytes_pp, start, end);
};