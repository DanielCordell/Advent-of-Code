package day6b
import java.io.File

data class Planet(val name: String, val orbits: String?);

val planets = hashMapOf("COM" to Planet("COM", null))
val inputs = File("src/input.txt").readLines().map { it.split(")").toTypedArray() }

fun countOrbits(planet: Planet, base: String, count: Int = 0): Int? =
    when (planet.name) {
        base -> count
        "COM" -> null
        else -> countOrbits(planets[planet.orbits]!!, base,count + 1)
    }

fun main() {
    inputs.forEach { planets.put(it[1], Planet(it[1], it[0])) }
    val mePlanet = planets[planets["YOU"]!!.orbits]!!;
    val santaPlanet = planets[planets["SAN"]!!.orbits]!!;
    val meDownDistance = planets.map { it.key to countOrbits(mePlanet, it.key) }.toMap().filterValues { it != null }.filterKeys { it != "COM" }
    val santaDownDistance = planets.map { it.key to countOrbits(santaPlanet, it.key) }.toMap().filterValues { it != null }.filterKeys { it != "COM" }
    val intersections = meDownDistance.map { it.key }.intersect(santaDownDistance.map { it.key }).asSequence().map { meDownDistance.getValue(it)!! + santaDownDistance.getValue(it)!! };
    println(intersections)
    println(intersections.sorted().firstOrNull())
}