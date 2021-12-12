package Day3

import Shared.fileAsStrings

fun main() {
    var input = fileAsStrings("src/Day3/input.txt")

    var oxygenAndCO2 = input to input;

    var index = 0;
    while (oxygenAndCO2.first.count() > 1 || oxygenAndCO2.second.count() > 1)
    {
        oxygenAndCO2 = getListOfItemsToKeep(oxygenAndCO2, index++)
    }

    println(Integer.parseInt(oxygenAndCO2.first.first(), 2) * Integer.parseInt(oxygenAndCO2.second.first(), 2))
}

fun getListOfItemsToKeep(inputs: Pair<List<String>, List<String>>, index: Int) : Pair<List<String>, List<String>>
{
    var countOfStart = count(inputs.first, index) to count(inputs.second, index)

    var moreZero = (countOfStart.first.first > countOfStart.first.second) to (countOfStart.second.first > countOfStart.second.second)

    var processed = inputs.first.filter { (it[index] == '0') == moreZero.first } to inputs.second.filter { (it[index] == '1') == moreZero.second }

    return (if (processed.first.count() == 0) (inputs.first) else processed.first) to (if (processed.second.count() == 0) (inputs.second) else processed.second)
}

fun count (input: List<String>, index: Int): Pair<Int, Int> {
    return input
        .fold(0 to 0) { count, input -> if (input[index] == '0') (count.first + 1 to count.second) else (count.first to count.second + 1) }
}