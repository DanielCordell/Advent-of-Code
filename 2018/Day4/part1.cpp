#include <string>
#include <vector>
#include <map>
#include <fstream>
#include <algorithm>
#include <iostream>

struct Guard {
	int guardID = -1;
	int timeAsleep = 0;

	//sleep - wake in minutes from 0:0
	std::vector<std::pair<int, int>> times;

	Guard(int id) { guardID = id;  }

	void addTimeAsleep(int wakesMinute, int wakesHour, int asleepMinute, int asleepHour) {
		auto i = wakesMinute + wakesHour * 60;
		auto j = asleepMinute + asleepHour * 60;
		times.push_back(std::make_pair(j, i));
		timeAsleep += i - j;
	}
};

int main() {
	std::fstream input{ "Day4/input.txt" };
	std::vector<std::string> inputVals;
	typedef std::shared_ptr<Guard> guardptr;
	std::string in;
	while (getline(input, in)) {
		inputVals.push_back(in);
	}
	input.close();
	sort(inputVals.begin(), inputVals.end());

	std::vector<guardptr> guards;
	guardptr guard = nullptr;

	int asleepHour = 0;
	int asleepMinute = 0;

	for (std::string line : inputVals) {
		auto find = line.find("Guard");
		if (find != std::string::npos) {
			if (guard != nullptr && std::find(guards.begin(), guards.end(), guard) == guards.end()) {
				guards.push_back(guard);
			}
			int ID;
			sscanf_s(line.substr(19).c_str(), "Guard #%d begins shift", &ID);
			auto g = std::find_if(guards.begin(), guards.end(), [ID](guardptr& g) {return g->guardID == ID; });
			if (g != guards.end())
				guard = *g;
			else guard = std::make_shared<Guard>(ID);
		}
		else if (line.find("falls asleep") != std::string::npos) {
			sscanf_s(line.substr(12).c_str(), "%d:%d] falls asleep", &asleepHour, &asleepMinute);
		}
		else if (line.find("wakes up") != std::string::npos) {
			int wakesHour;
			int wakesMinute;
			sscanf_s(line.substr(12).c_str(), "%d:%d] wakes up", &wakesHour, &wakesMinute);
			guard->addTimeAsleep(wakesMinute, wakesHour, asleepMinute, asleepHour);
		}
	}
	std::sort(guards.begin(), guards.end(), [](guardptr& a, guardptr& b) {return a->timeAsleep > b->timeAsleep; });
	guardptr guardToTest = guards[0];

	std::map<int, int> minuteToAmount;
	for (std::pair<int, int>& times : guardToTest->times) {
		for (int i = times.first; i < times.second; ++i) {
			if (minuteToAmount.find(i) == minuteToAmount.end()) minuteToAmount[i] = 1;


			else minuteToAmount[i]++;
		}
	}
	auto largest = minuteToAmount.begin();
	for (auto m = minuteToAmount.begin(); m != minuteToAmount.end(); ++m) {
		if (m->second > largest->second) largest = m;
	}
	std::cout << guardToTest->guardID * largest->first;
}