package Day3

import Shared.fileAsStrings

fun main()
{
    var input = fileAsStrings("src/Day3/input.txt")

    var output = input.fold(List(input[0].length) {0 to 0}) { columns, row ->
        row.mapIndexed { i, c -> (if (c == '0') (columns[i].first + 1) to columns[i].second else columns[i].first to (columns[i].second + 1)) }
    }.fold("" to "") {acc, bitcount -> when {
        bitcount.first > bitcount.second -> acc.first + "0" to acc.second + "1"
        else -> acc.first + "1" to acc.second + "0"
    } }.let { Integer.parseInt(it.first, 2) to Integer.parseInt(it.second, 2) }

    println(output.first * output.second)
}