import java.io.File
import java.lang.Math.abs

fun main() {
    val inputs = ArrayList<Pair<Int, Int>>().apply {
        File("input.txt").forEachLine {line ->
            line.split(", ").map { it.toInt() }.also { this.add(Pair(it[0], it[1])) }
        }
    }

    val allx = inputs.map { it.first }
    val ally = inputs.map { it.second }
    val minX = allx.min()!!
    val minY = ally.min()!!
    val maxX = allx.max()!!
    val maxY = ally.max()!!

    val map = HashMap<Pair<Int, Int>, Int>()
    for (x in minX..maxX) {
        for (y in minY..maxY) {
            map.put(Pair(x, y), manhattansum(x, y, inputs))
        }
    }
    val setofremovals = mutableSetOf<Int>()
    map.forEach { t, u ->
        if (t.first < minX + 1 || t.first > maxX - 1 || t.second < minY + 1 || t.second > maxY - 1) {
            setofremovals.add(u)
        }
    }
    println(map.filter{ it.value !in setofremovals }.values.groupingBy { it }.eachCount().values.max())

}

private fun manhattansum(x: Int, y: Int, inputs: ArrayList<Pair<Int,Int>>): Int {
    val inputsWithDistance = inputs.associate { it to abs(x - it.first) + abs(y - it.second) }
    val minvalue = inputsWithDistance.values.min()!!
    return when (inputsWithDistance.values.count { it == minvalue }) {
        0 -> throw Exception("How this happen")
        1 -> inputsWithDistance.values.indexOf(minvalue)
        else -> -1
    }
}