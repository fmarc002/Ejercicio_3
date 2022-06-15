# Ejercicio_3
Selenium with C# language and NUnit

Testing Automatizado
Ejercitación 3:
1. Instalar Visual Studio: Instalar VS 2013 Ultimate en adelante o la versión Comunity del sitio de Microsoft.
2. Crear proyecto de Test Unitario e importar librerías necesarias: Crear proyecto de test unitario en Visual Studio y agregar las librerías de Webdriver y de Chrome driver.
3. Crear los primeros tests:
1. Agregar test que
1. vaya a la página de https://www.ultimateqa.com/automation/
2. Ir a la sección “NN” (cada pasante le toca una) y verifique la visualización de los elementos principales de la página, verificar su texto y/o valor por defecto.
2. Correr el test y lograr que pase
3. Clonar el test y cambiar alguna assertion para lograr que falle el segundo test
4. Crear otro test que realice alguna acción/workflow en la página y agregar las aserciones del resultado.
4. Agregar otra clase test: Agregar otra clase de test para otra sección diferente de la utilizada en el ejercicio anterior e implementar 2 tests en esa clase:
1. Uno que verifique el contenido propio.
2. Otro que haga alguna acción permitida en la página y se verifiquen los resultados de esa acción.
5. Implementar métodos Initialize y Cleanup: Implementar métodos cleanup e initialize para todas las clases de que se tengan. Poner el código común en la clase tanto al inicializar como al terminar.
6. Implementar clase base test: La idea es implementar una clase base test que luego extiendan las clases test que se definieron, donde se hagan pasos básicos y comunes a todos los tests. La clase base test tendría su Initialize y Cleanup que es común a todos los test de todas las clases.
7. Extender Webdriver: Extender Webdriver para que se haga un explicit wait del elemento cada vez que se lo busca. Ver ejemplo de cómo se hace en el proyecto ejemplo de git.
