package Day6

import Shared.fileAsStrings

fun main() {
    var input = fileAsStrings("src/Day6/input.txt")[0].split(",".toRegex()).map { Integer.parseInt(it) }

    for (i in 0 until 80)
    {
        input = input.map { if (it == 0) listOf(6, 8) else listOf(it-1) }.flatten()
    }

    println(input.count())
}