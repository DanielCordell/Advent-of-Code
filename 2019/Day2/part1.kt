import java.io.File

fun main() {
    val inputs = File("src/input.txt").readLines()[0].split(",").map { it.toInt() }.toIntArray()

    var index = 0;
    while (inputs[index] != 99) {
        val opcode = inputs[index];
        val in1 = inputs[inputs[index + 1]];
        val in2 = inputs[inputs[index + 2]];
        inputs[inputs[index + 3]] = if (opcode == 1) in1 + in2 else if (opcode == 2) in1 * in2 else -1
        index += 4;
    }
    println(inputs[0]);
}