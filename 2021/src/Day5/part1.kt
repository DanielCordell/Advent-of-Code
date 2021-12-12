package Day5

import Shared.fileAsStrings

fun main() {
    var input = fileAsStrings("src/Day5/input.txt")
    var parsedInput = input.map { line -> line.split(" -> ".toRegex()).map { pair -> pair.split(",".toRegex()).map { num -> Integer.parseInt(num) }.let { it[0] to it[1] } }.let { it[0] to it[1] } }

    var duplicates = parsedInput.map { coordPair ->
        when {
            coordPair.first.first == coordPair.second.first -> {
                ((coordPair.first.second)toward(coordPair.second.second)).map { coordPair.first.first to it }
            }
            coordPair.first.second == coordPair.second.second -> {
                ((coordPair.first.first)toward(coordPair.second.first)).map { it to coordPair.first.second }
            }
            else -> listOf()
        }
    }
        .flatten()
        .groupingBy { it }
        .eachCount()
        .filter { it.value > 1 }

    println(duplicates.count())
}

private infix fun Int.toward(to: Int): IntProgression {
    val step = if (this > to) -1 else 1
    return IntProgression.fromClosedRange(this, to, step)
}
