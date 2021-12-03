package Day2

import Shared.fileAsSplitStrings

fun main()
{
    var input = fileAsSplitStrings("src/Day2/input.txt").map { it[0] to it[1].toInt() }
    var output = input.fold(Triple(0, 0, 0)) { curr, inst ->
        when(inst.first)
        {
            "forward" -> Triple(curr.first + inst.second, curr.second + inst.second * curr.third, curr.third)
            "up" -> Triple(curr.first, curr.second, curr.third - inst.second)
            "down" -> Triple(curr.first, curr.second, curr.third + inst.second)
            else -> curr
        }
    }

    println(output.first * output.second)
}