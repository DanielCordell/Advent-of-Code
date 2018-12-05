#include <string>
#include <vector>
#include <fstream>
#include <functional>
#include <iostream>


int main() {
	std::fstream input{"Day2/list.txt"};
	std::vector<std::string> inputVals;
	std::string in;
	while (getline(input, in)) {
		inputVals.push_back(in);
	}
	input.close();
	int wordSize = in.size();
	for (auto i = inputVals.begin(); i < inputVals.end(); ++i) {
		for (auto j = inputVals.begin(); j < inputVals.end(); ++j) {
			if (i == j) continue;
			bool foundMismatch = false;
			int numberMatched = 0;
			for (int ind = 0; ind < wordSize; ++ind) {
				if (i->at(ind) == j->at(ind)) ++numberMatched;
				else if (foundMismatch) break;
				else foundMismatch = true;
			}
			if (numberMatched == wordSize - 1) {
				std::cout << *i << " " << *j;
				return 0;
			}
		}
	}
}
