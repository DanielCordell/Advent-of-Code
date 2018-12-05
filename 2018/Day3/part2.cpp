


#include <string>
#include <vector>
#include <fstream>
#include <map>
#include <algorithm>
#include <iostream>

struct Claim {

	int ID;

	int posX, posY;
	int sizeX, sizeY;

	bool overlaps = false;

	Claim(std::string s) {
		sscanf_s(s.c_str(), "#%d @ %d,%d: %dx%d", &ID, &posX, &posY, &sizeX, &sizeY);
	}
};


int main() {
	std::fstream input{ "Day3/list.txt" };
	typedef std::map<std::pair<int, int>, int> mapType;
	mapType claims;
	std::vector<Claim> inputVals;
	std::string in;
	while (getline(input, in)) {
		inputVals.emplace_back(in);
	}
	input.close();

	for (Claim& claim : inputVals) {
		for (int i = 0; i < claim.sizeX; ++i) {
			for (int j = 0; j < claim.sizeY; ++j) {
				auto pos = std::make_pair(i + claim.posX, j + claim.posY);
				auto found = claims.find(std::make_pair(i + claim.posX, j + claim.posY));
				if (found == claims.end()) {
					claims.insert({ pos, claim.ID - 1 });
				}
				else {
					inputVals.at(claim.ID-1).overlaps = true;
					inputVals.at((*found).second).overlaps = true;
				}
			}
		}
	}

	auto found = std::find_if(inputVals.begin(), inputVals.end(), [](Claim& c)
	{
		return !c.overlaps;
	});

	if (found == inputVals.end()) std::cout << "None found";
	else std::cout << found->ID;
	return 0;
}
