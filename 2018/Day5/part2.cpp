#include <fstream>
#include <vector>
#include <string>
#include <iterator>
#include <cctype>
#include <iostream>
#include <map>
#include <algorithm>

int main() {
	std::fstream input{ "Day5/input.txt" };
	std::string truein;
	getline(input, truein);
	input.close();
	typedef std::pair<const char, int> mapType;
	std::map<char, int> afterReductionCount;

	for (char c = 'a'; c <= 'z'; ++c) {
		std::string in = truein;
		in.erase(remove(in.begin(), in.end(), c), in.end());
		in.erase(remove(in.begin(), in.end(), toupper(c)), in.end());
		bool finished = false;
		while (!finished) {
			finished = true;
			for (auto it = begin(in); it != end(in) && next(it) != end(in); ++it) {
				char first = *it;
				char second = *next(it);
				bool firstlower = islower(first);
				bool secondlower = islower(second);
				if (firstlower == secondlower) continue;
				if (tolower(first) == tolower(second)) {
					in.erase(it, next(it, 2));
					finished = false;
					break;
				}
			}
		}
		afterReductionCount[c] = in.length();

	}
	std::cout << (*std::min_element(afterReductionCount.begin(), afterReductionCount.end(), [](mapType& a, mapType& b) {return a.second < b.second; })).second;
}
