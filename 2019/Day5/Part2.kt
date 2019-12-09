package day5b
import java.io.File

val inputs = File("src/input.txt").readLines()[0].split(",").map { it.toInt() }.toTypedArray()
var terminate = false;
var hasModifiedPC = false;
var pc = 0;

fun getInputFromMode(value: Int, mode: Char): Int {
    return if (mode == '0') inputs[value] else value;
}

fun getModesString(modes: Int, size: Int) = "%0${size}d".format(modes)

fun add(input: List<Int>, modes: Int){
    val modesStr = getModesString(modes, input.size);
    val input1 = getInputFromMode(input[0], modesStr[2]);
    val input2 = getInputFromMode(input[1], modesStr[1]);
    inputs[input[2]] = input1 + input2;
}

fun mult(input: List<Int>, modes: Int) {
    val modesStr = getModesString(modes, input.size);
    val input1 = getInputFromMode(input[0], modesStr[2]);
    val input2 = getInputFromMode(input[1], modesStr[1]);
    inputs[input[2]] = input1 * input2;
}

fun input(input: List<Int>, modes: Int) {
    val modesStr = getModesString(modes, input.size);
    println("Give input: ")
    val number = Integer.valueOf(readLine())
    inputs[input[0]] = number;
}

fun output(input: List<Int>, modes: Int) {
    val modesStr = getModesString(modes, input.size);
    println(getInputFromMode(input[0], modesStr[0]))
}

fun stop(input: List<Int>, modes: Int) {
    terminate = true;
}

fun jumpIfTrue(input: List<Int>, modes: Int) {
    val modesStr = getModesString(modes, input.size);
    val inputTest = getInputFromMode(input[0], modesStr[1]);
    if (inputTest != 0) {
        pc = getInputFromMode(input[1], modesStr[0]);
        hasModifiedPC = true;
    };
}

fun jumpIfFalse(input: List<Int>, modes: Int) {
    val modesStr = getModesString(modes, input.size);
    val inputTest = getInputFromMode(input[0], modesStr[1]);
    if (inputTest == 0) {
        pc = getInputFromMode(input[1], modesStr[0]);
        hasModifiedPC = true;
    };
}

fun lessThan(input: List<Int>, modes: Int) {
    val modesStr = getModesString(modes, input.size);
    val input1 = getInputFromMode(input[0], modesStr[2]);
    val input2 = getInputFromMode(input[1], modesStr[1]);
    inputs[input[2]] = if (input1 < input2) 1 else 0
}

fun equalTo(input: List<Int>, modes: Int) {
    val modesStr = getModesString(modes, input.size);
    val input1 = getInputFromMode(input[0], modesStr[2]);
    val input2 = getInputFromMode(input[1], modesStr[1]);
    inputs[input[2]] = if (input1 == input2) 1 else 0
}

//                      Op        NoOfInp  Inputs, Modes   Outputs
val operations = hashMapOf<Int, Pair<Int, (List<Int>, Int) -> Unit>>(
    1 to Pair(3, ::add), //Add
    2 to Pair(3, ::mult), //Mult
    3 to Pair(1, ::input), //Input
    4 to Pair(1, ::output), //Output
    5 to Pair(2, ::jumpIfTrue), //Add
    6 to Pair(2, ::jumpIfFalse), //Mult
    7 to Pair(3, ::lessThan), //Input
    8 to Pair(3, ::equalTo), //Output
    99 to Pair(0, ::stop)
)

fun main() {
    while (!terminate) {
        val instruction = inputs[pc].toString();
        println("Parsing instruction $instruction at position $pc")
        val opCode = instruction.takeLast(2).toInt()
        val modes = instruction.dropLast(2).let {if (it.isEmpty()) 0 else it.toInt()}
        val operation = operations[opCode]!!;
        val operationInputs = inputs.slice(pc+1..pc+operation.first)
        operation.second(operationInputs, modes);
        if (!hasModifiedPC)
            pc += (operation.first + 1)
        else
            hasModifiedPC = false;
    }
    println(inputs[0]);
}
