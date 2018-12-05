#include <string>
#include <vector>
#include <fstream>
#include <map>
#include <algorithm>
#include <functional>
#include <iostream>

typedef std::map<char, int> mapType;

bool isN(mapType::value_type it, int n) {
	return it.second == n;
}

class Checksum {
	mapType charCountMap;
public:
	Checksum(std::string s) {
		for (char c : s) {
			mapType::iterator lb = charCountMap.lower_bound(c);

			if (lb != charCountMap.end() && !(charCountMap.key_comp()(c, lb->first))) {
				lb->second++;
			}
			else {
				charCountMap.insert(lb, mapType::value_type(c, 1));
			}
		}
	}

	bool getThree() {
		using namespace std::placeholders;
		return count_if(charCountMap.begin(), charCountMap.end(), bind(isN, _1, 3)) > 0;
	}

	bool getTwo() {
		using namespace std::placeholders;
		return count_if(charCountMap.begin(), charCountMap.end(), bind(isN, _1, 2)) > 0;
	}
};


int main() {
	std::fstream input{"Day2/list.txt"};
	std::vector<Checksum> inputVals;
	std::string in;
	while (getline(input, in)) {
		inputVals.emplace_back(in);
	}
	input.close();

	int two = 0;
	int three = 0;

	std::for_each(inputVals.begin(), inputVals.end(), [&two, &three](Checksum& s) {
	              if (s.getTwo()) two++;
	              if (s.getThree()) three++;
              });

	std::cout << two * three;
}
