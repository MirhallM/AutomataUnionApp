# AutomataUnionApp

Aplicación de escritorio en C# (Windows Forms) para la clase de Computación
Teórica. Valida Autómatas Finitos Deterministas (DFA) y calcula la unión
entre dos autómatas válidos, mostrando el autómata resultante y permitiendo
probar cadenas sobre él.

## Restricción técnica cumplida

Todo el proyecto está construido **sin colecciones ni librerías nativas**
del lenguaje (`List`, `Dictionary`, `HashSet`, LINQ, `.IndexOf()`,
`.Contains()`, `String.Split()`, expresiones regulares, etc.). En su lugar:

- `Estructuras/NodoLista.cs` y `Estructuras/Lista.cs` — lista enlazada
  genérica implementada desde cero (nodos con punteros, sin arrays), usada
  para representar estados, alfabeto, finales, transiciones y errores.
- Toda búsqueda, inserción, conteo y recorrido se hace con algoritmos
  propios (bucles `while` explícitos sobre los nodos), incluyendo el
  parseo manual de texto en `Utilidades/TextoUtil.cs` (sin `Split()` ni
  `IndexOf()`).

## Características

- **Validación estricta de DFA**: unicidad de estados y símbolos, símbolos
  reservados, estado inicial y finales válidos, y completitud +
  determinismo de la función de transición δ, con mensajes de error
  específicos.
- **Unión de autómatas**: valida que los alfabetos coincidan exactamente y
  construye el autómata producto (par de estados, transiciones combinadas,
  aceptación por disyunción OR).
- **Prueba de cadenas**: veredicto triple (Autómata 1 / Autómata 2 / Unión)
  y derivación formal paso a paso de la función de transición extendida
  δ̂ ("delta gorrito") sobre el autómata unión.
- **Persistencia**: los autómatas válidos se guardan en un archivo de
  texto propio (`automatas.dat`), con lectura/escritura también hechas a
  mano.

## Estructura del proyecto

```
AutomataUnionApp/
├── Dominio/          Automata, Transicion
├── Estructuras/      NodoLista<T>, Lista<T> (lista enlazada propia)
├── Validacion/        ValidadorDFA
├── Union/             OperacionUnion
├── Simulacion/         SimuladorCadenas, ResultadoSimulacion, DeltaGorritoUtil
├── Persistencia/       GestorArchivoAutomatas
├── Utilidades/         TextoUtil, TablaAutomataUtil
├── Formularios/         FormPrincipal, FormEditarAutomata, FormUnion,
│                       FormPruebaCadenas, FormVerGuardados
└── Program.cs
```

## Requisitos

- Visual Studio 2022
- .NET 8.0 SDK (con soporte de Windows Forms)

## Cómo ejecutar

1. Clona el repositorio.
2. Abre `AutomataUnionApp.sln` en Visual Studio 2022.
3. Compila y ejecuta (F5). La app inicia en el menú principal
   (`FormPrincipal`).

## Cómo usar

1. **Nuevo autómata**: escribe estados, alfabeto, estado inicial y finales
   → *Generar tabla de transiciones* → completa el destino de cada fila →
   *Validar* → si es válido, *Guardar*.
2. **Realizar unión**: selecciona dos autómatas ya guardados y válidos →
   *Generar unión*. Si los alfabetos no coinciden, se muestra el símbolo
   específico que falta en cada uno.
3. **Probar cadenas**: desde la pantalla de unión, tras generar la unión,
   *Probar cadenas* abre la pantalla donde se evalúa una cadena en los
   tres autómatas y se muestra la derivación δ̂ completa.
4. **Ver autómatas guardados**: lista todos los autómatas guardados; al
   seleccionar uno se muestra su tabla de transiciones completa.

## Formato de persistencia

Los autómatas se guardan en texto plano en `automatas.dat`, un bloque por
autómata:

```
AUTOMATA
NOMBRE:Automata1
VALIDO:true
ESTADOS:q0,q1,q2
ALFABETO:a,b
INICIAL:q0
FINALES:q2
TRANSICION:q0,a,q1
TRANSICION:q0,b,q0
FIN_AUTOMATA
```

## Autor

Marcelo — Sistemas Computacionales, proyecto de Computación Teórica.
