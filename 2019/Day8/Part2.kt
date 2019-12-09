package day8b

import java.io.File

val inputs = File("src/input.txt").readLines()[0].map { it.toString().toInt() }

fun main() {
    val layers = inputs.chunked(25 * 6).map { it.chunked(25) }
    val output = List(6) { List(25) {2}.toTypedArray() }.toTypedArray()
    println(output);
    for (i in 0 until 25) {
        for (j in 0 until 6) {
            for (k in (layers.indices)) {
                println("i $i, j $j, k $k")
                if (output[j][i] == 2) output[j][i] = layers[k][j][i]
                else break;
            }
        }
    }
    for (list in output) {
        println(list.joinToString(" ") { it.toString().let { if (it == "1") "1" else " " } });
    }
}
