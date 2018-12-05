#include <fstream>
#include <vector>
#include <iostream>
#include <string>

int main() {
	std::fstream input{"Day1\list.txt"};
	std::vector<int> inputVals;
	std::vector<int> past{0};
	std::string in;
	int result = 0;
	while (getline(input, in)) {
		inputVals.push_back(stoi(in));
	}
	input.close();
	bool isDone = false;
	while (!isDone) {
		for (int val : inputVals) {
			result += val;
			if (find(past.begin(), past.end(), result) != past.end()) {
				isDone = true;
				break;
			}
			past.push_back(result);
		}
	}

	std::cout << "Val: " << result;
}
