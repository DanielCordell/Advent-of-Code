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
            manhattansum(x, y, inputs).also {
                val result = if (it < 10000) it else -1
                map.put(Pair(x, y), result)
            }
        }
    }
    println(map.values.filter { it != -1 }.size)
}

private fun manhattansum(x: Int, y: Int, inputs: ArrayList<Pair<Int,Int>>)
        = inputs.map { abs(x - it.first) + abs(y - it.second) }.sum()
