package Day2

import Shared.fileAsSplitStrings

fun main()
{
    var input = fileAsSplitStrings("src/Day2/input.txt").map { it[0] to it[1].toInt() }
    var output = input.fold(0 to 0) { curr, inst ->
        when(inst.first)
        {
            "forward" -> curr.first + inst.second to curr.second
            "up" -> curr.first to curr.second - inst.second
            "down" -> curr.first to curr.second + inst.second
            else -> curr
        }
    }

    println(output.first * output.second)
}