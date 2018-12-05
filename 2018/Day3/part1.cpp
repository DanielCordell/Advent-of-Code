


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
					claims.insert({ pos, 1 });
				}
				else ++(*found).second;
			}
		}
	}


	int res = std::count_if(claims.begin(), claims.end(), [](mapType::value_type& val)
	{
		return val.second >= 2;
	});

	std::cout << res;


}
