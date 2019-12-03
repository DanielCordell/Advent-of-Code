import java.io.File

fun parse(input: List<Pair<Char, Int>>): ArrayList<Pair<Int, Int>> {
    val points = arrayListOf(Pair(0,0))
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
    return arrayListOf<Pair<Int, Int>>().apply {
        for (i in 1 until points.size) {
            val p1 = points[i - 1]
            val p2 = points[i]
            this.addAll(
                if (p1.first == p2.first) {
                    (if (p1.second < p2.second) p1.second until p2.second else p1.second downTo p2.second+1).map { Pair(p1.first, it) }
                } else {
                    (if (p1.first < p2.first) p1.first until p2.first else p1.first downTo p2.first+1).map { Pair(it, p1.second) }
                }
            )
        }
    }
}

fun main() {
    val inputs = File("src/input.txt").readLines().map { it.split(",").map { comm -> Pair(comm[0], comm.drop(1).toInt()) } }
    val in1 = parse(inputs[0]).apply { remove(Pair(0,0)) }
    val in2 = parse(inputs[1]).apply { remove(Pair(0,0)) }
    in1.intersect(in2).minBy { in1.indexOf(it) + in2.indexOf(it) }.also { println(in1.indexOf(it) + in2.indexOf(it) + 2) }
}