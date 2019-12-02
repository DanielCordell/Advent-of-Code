import java.io.File

fun main() {
    val inputs = ArrayList<Int>().apply {
        File("src/input.txt").forEachLine { this.add(it.toInt()) }
    }
    println(inputs.map { (it / 3) - 2 }.sum());
}

