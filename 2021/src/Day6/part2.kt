package Day6

import Shared.fileAsStrings

fun main() {
    var input = fileAsStrings("src/Day6/input.txt")[0].split(",".toRegex()).map { it.toLong() }.groupingBy { it }.eachCount().map { it.key to it.value.toLong() }.toList()
    // Left - days, right - count
    for (i in 0 until 256)
    {
        input = input.map { it.first - 1L to it.second }
            .map { if (it.first < 0) listOf(6L to it.second, 8L to it.second) else listOf(it) }
            .flatten()
            .groupBy { it.first }
            .map { it.key to it.value.map { itt -> itt.second }.sum() }
    }

    println(input.fold(0L) { sum, count -> sum + count.second })
}