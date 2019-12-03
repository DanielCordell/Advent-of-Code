import java.io.File
import kotlin.math.abs
import kotlin.math.max
import kotlin.math.min

fun parse2(input: List<Pair<Char, Int>>): ArrayList<Pair<Int, Int>> {
    val points = arrayListOf<Pair<Int, Int>>()
    for (comm in input) {
        var start = points.lastOrNull() ?: Pair(0,0)
        when (comm.first) {
            'R' -> start = Pair(start.first - comm.second, start.second)
            'U' -> start = Pair(start.first, start.second - comm.second)
            'D' -> start = Pair(start.first, start.second + comm.second)
            'L' -> start = Pair(start.first + comm.second, start.second)
        }
        points.add(start)
    }
    points.addAll(arrayListOf<Pair<Int, Int>>().apply { for (i in 1 until points.size) {
        val p1 = points[i-1]
        val p2 = points[i]
        addAll(
            if (p1.first == p2.first) {
                (min(p1.second, p2.second)..max(p1.second, p2.second)).map { Pair(p1.first, it) }
            } else {
                (min(p1.first, p2.first)..max(p1.first, p2.first)).map { Pair(it, p1.second) }
            }
        )
    } })
    return points
}

fun main() {
    val inputs = File("src/input.txt").readLines().map { it.split(",").map { comm -> Pair(comm[0], comm.drop(1).toInt()) } }
    val intersect = parse2(inputs[0]).intersect(parse2(inputs[1])).map { abs(it.first) + abs(it.second) }
    println(intersect.min())
}