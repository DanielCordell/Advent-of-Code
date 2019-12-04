import java.io.File

fun doesPass(i: Int): Boolean {
    val iString = i.toString();
    return iString.zipWithNext().let { it.any { it.first == it.second } && it.all { it.first <= it.second } }
}

fun main() {
    val inputs = File("src/input.txt").readLines()[0].split("-").map { it.toInt() }

    var count = 0;
    for (i in (inputs[0]..inputs[1])) {
        if (doesPass(i)) count++
    }
    println(count)
}