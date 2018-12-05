#include <fstream>
#include <vector>
#include <string>
#include <iterator>
#include <cctype>
#include <iostream>

int main() {
	std::fstream input{ "Day5/input.txt" };
	std::string in;
	getline(input, in);
	input.close();

	bool finished = false;
	while (!finished) {
		finished = true;
		for (auto it = begin(in); it != end(in) && next(it) != end(in); ++it) {	
			char first = *it;
			char second = *next(it);
			bool firstlower = islower(first), secondlower = islower(second);
			if (firstlower == secondlower) continue;
			if (tolower(first) == tolower(second)) {
				in.erase(it, next(it,2));
				finished = false;
				break;
			}
		}
	}
	std::cout << in.size();
}
