package day8a

import java.io.File

val inputs = File("src/input.txt").readLines()[0].map { it.toString().toInt() }

fun main() {
    val layers = inputs.chunked(25 * 6)
    val indexWithFewestZeros = layers.map { it.count { it == 0 } }.let { it.indexOf(it.min()) }
    println(layers[indexWithFewestZeros].let { it.count { it == 1 } * it.count { it == 2 } })
}