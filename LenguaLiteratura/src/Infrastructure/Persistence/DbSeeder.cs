using LenguaLiteratura.src.Domain.Entities;

namespace LenguaLiteratura.src.Infrastructure
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            if (!db.SpellingExercises.Any())
            {
                db.SpellingExercises.AddRange(
                    new SpellingExercise
                    {
                        Sentence = "Ayer yo ___ al parque con mis amigos.",
                        Options = new() { "fui", "fue", "fuí" },
                        CorrectAnswer = "fui",
                        Explanation = "«Fui» (verbo ir) es monosílaba y no lleva tilde."
                    },
                    new SpellingExercise
                    {
                        Sentence = "Ella ___ al colegio todos los días.",
                        Options = new() { "va", "ba", "vaya" },
                        CorrectAnswer = "va",
                        Explanation = "El verbo ir se escribe con «v»: ella va."
                    },
                    new SpellingExercise
                    {
                        Sentence = "___ qué película vemos hoy.",
                        Options = new() { "a ver", "haber", "aver" },
                        CorrectAnswer = "a ver",
                        Explanation = "«A ver» equivale a «vamos a mirar o comprobar». «Haber» es un verbo auxiliar."
                    },
                    new SpellingExercise
                    {
                        Sentence = "El ___ de matemáticas es difícil.",
                        Options = new() { "examen", "exámen", "examén" },
                        CorrectAnswer = "examen",
                        Explanation = "«Examen» es llana y termina en «n», por eso no lleva tilde."
                    },
                    new SpellingExercise
                    {
                        Sentence = "Mi ___ favorito es el azul.",
                        Options = new() { "color", "colór", "cólor" },
                        CorrectAnswer = "color",
                        Explanation = "«Color» es aguda y termina en «r», por eso no lleva tilde."
                    });
            }

            if (!db.ReadingTexts.Any())
            {
                db.ReadingTexts.Add(new ReadingText
                {
                    Title = "El gato de Lucía",
                    Content = "Lucía encontró un gato pequeño bajo la lluvia. Estaba mojado y temblaba de frío. " +
                              "Lo llevó a su casa, lo secó con una toalla y le dio un poco de leche. " +
                              "Desde ese día, el gato dormía junto a su cama.",
                    Questions = new()
                    {
                        new() { Text = "¿Dónde encontró Lucía al gato?",
                            Options = new() { "Bajo la lluvia", "En el jardín", "En la escuela" },
                            CorrectAnswer = "Bajo la lluvia",
                            Explanation = "El texto dice que lo encontró bajo la lluvia." },
                        new() { Text = "¿Cómo ayudó Lucía al gato?",
                            Options = new() { "Lo secó y le dio leche", "Lo dejó en la calle", "Lo llevó al veterinario" },
                            CorrectAnswer = "Lo secó y le dio leche",
                            Explanation = "Lo secó con una toalla y le dio leche." },
                        new() { Text = "¿Qué significa «temblaba»?",
                            Options = new() { "Se movía por el frío", "Dormía tranquilo", "Corría rápido" },
                            CorrectAnswer = "Se movía por el frío",
                            Explanation = "Temblar es moverse con pequeñas sacudidas, por ejemplo por el frío." },
                        new() { Text = "¿Cuál es la idea principal del texto?",
                            Options = new() { "Lucía rescató y cuidó a un gato", "Llovió todo el día", "Lucía no tenía mascotas" },
                            CorrectAnswer = "Lucía rescató y cuidó a un gato",
                            Explanation = "Todo el texto trata de cómo Lucía cuida al gato que encontró." }
                    }
                });
            }

            // Si todavía no existe ningún texto de adolescentes, lo crea
            if (!db.ReadingTexts.Any(t => t.Group == "teenagers"))
            {
                db.ReadingTexts.Add(new ReadingText
                {
                    Title = "La biblioteca del pueblo",
                    Group = "teenagers",
                    Content = "Mateo llegó al pueblo a mediados de invierno, cuando las calles estaban casi vacías y el viento arrastraba hojas secas. " +
                              "Su abuela le había hablado tanto de la vieja biblioteca que, apenas dejó la maleta, caminó hasta ella. " +
                              "Encontró la puerta entreabierta y un cartel que decía «Cerrada por reformas». Dudó un momento, " +
                              "pero al ver una luz encendida al fondo, empujó la puerta. Dentro, una bibliotecaria clasificaba libros sin levantar la vista. " +
                              "—Llegas justo a tiempo —dijo—. Tu abuela me contó que vendrías hoy.",
                    Questions = new()
                    {
                        new() { Text = "¿Qué se puede deducir del final del texto?",
                            Options = new() { "La abuela ya había avisado de la visita de Mateo", "Mateo nunca había oído hablar de la biblioteca", "La biblioteca llevaba años abandonada" },
                            CorrectAnswer = "La abuela ya había avisado de la visita de Mateo",
                            Explanation = "La bibliotecaria dice que la abuela le contó que Mateo vendría ese día." },
                        new() { Text = "¿Qué significa «entreabierta»?",
                            Options = new() { "Abierta solo un poco", "Cerrada con llave", "Abierta por completo" },
                            CorrectAnswer = "Abierta solo un poco",
                            Explanation = "El prefijo «entre-» indica algo a medias: ni abierta ni cerrada del todo." },
                        new() { Text = "¿Por qué dudó Mateo antes de entrar?",
                            Options = new() { "Porque el cartel decía que estaba cerrada", "Porque le daba miedo la bibliotecaria", "Porque no recordaba el camino" },
                            CorrectAnswer = "Porque el cartel decía que estaba cerrada",
                            Explanation = "El cartel «Cerrada por reformas» le hizo dudar, pero la luz lo animó a entrar." },
                        new() { Text = "¿Cuál es la idea principal del texto?",
                            Options = new() { "Mateo visita la biblioteca de la que le habló su abuela y lo esperaban", "Mateo se pierde en el pueblo en invierno", "La biblioteca va a cerrar para siempre" },
                            CorrectAnswer = "Mateo visita la biblioteca de la que le habló su abuela y lo esperaban",
                            Explanation = "El texto cuenta su llegada a la biblioteca y que la bibliotecaria ya lo esperaba." }
                    }
                });
            }

            // Temas del asistente: se cargan solo si la tabla está vacía
            if (!db.AssistantTopics.Any())
            {
                db.AssistantTopics.AddRange(
                    new AssistantTopic
                    {
                        Keywords = "tilde,acento",
                        KidsAnswer = "La tilde es la rayita sobre una vocal, como en «avión». Las palabras agudas la llevan si terminan en n, s o vocal: avión, café. ¡Cuenta las sílabas y fíjate cuál suena más fuerte!",
                        TeensAnswer = "Las agudas llevan tilde si terminan en n, s o vocal (canción). Las llanas, si NO terminan en n, s o vocal (árbol). Las esdrújulas siempre la llevan (pájaro)."
                    },
                    new AssistantTopic
                    {
                        Keywords = "por qué,porque,porqué",
                        KidsAnswer = "«Por qué» se usa para preguntar: ¿Por qué lloras? «Porque» se usa para responder: Porque tengo sueño.",
                        TeensAnswer = "«Por qué» (separado y con tilde) introduce preguntas. «Porque» (junto) da la causa. «Porqué» es un sustantivo: «el porqué de todo». «Por que» es preposición + relativo: «el motivo por que luchas»."
                    },
                    new AssistantTopic
                    {
                        Keywords = "haber,a ver",
                        KidsAnswer = "«A ver» es mirar o comprobar: «A ver qué hay». «Haber» es un verbo: «Debe haber pan».",
                        TeensAnswer = "«A ver» (preposición + verbo ver) equivale a «vamos a ver». «Haber» es verbo auxiliar o impersonal: «ha de haber», «hubo un problema»."
                    },
                    new AssistantTopic
                    {
                        Keywords = "mayúscula,mayuscula",
                        KidsAnswer = "Escribimos con mayúscula al empezar una oración, después de un punto y en los nombres de personas y lugares: Lucía, Quito.",
                        TeensAnswer = "Se usa mayúscula inicial al comenzar un escrito, tras punto, en nombres propios, títulos de obras (solo la primera palabra) y en siglas."
                    },
                    new AssistantTopic
                    {
                        Keywords = "sinónimo,sinonimo",
                        KidsAnswer = "Un sinónimo es una palabra que significa casi lo mismo: «bonito» y «lindo».",
                        TeensAnswer = "Los sinónimos son palabras con significado semejante. Sirven para evitar repeticiones y precisar el matiz: «caminar», «andar», «deambular»."
                    },
                    new AssistantTopic
                    {
                        Keywords = "idea principal",
                        KidsAnswer = "La idea principal es lo más importante que cuenta el texto. Pregúntate: ¿de qué trata todo el texto?",
                        TeensAnswer = "La idea principal resume el tema central. Se identifica distinguiendo lo esencial de los detalles de apoyo y comprobando que englobe todo el texto."
                    },
                    new AssistantTopic
                    {
                        Keywords = "oración,oracion",
                        KidsAnswer = "Una oración dice algo completo. Tiene quién hace algo y qué hace: «Lucía lee un libro».",
                        TeensAnswer = "Una oración tiene sentido completo y se organiza en sujeto y predicado. Puede ser simple (un verbo) o compuesta (varios verbos)."
                    });
            }

            db.SaveChanges();
        }
    }
}