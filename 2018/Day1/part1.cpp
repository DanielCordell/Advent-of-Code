#include <fstream>
#include <vector>
#include <iostream>
#include <string>

int main() {
	std::fstream input{"Day1\list.txt"};
	std::string in;
	int result = 0;
	while (getline(input, in)) {
		int val = stoi(in);
		result += val;
	}

	std::cout << result;


}
