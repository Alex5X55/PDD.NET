using PDD.NET.Domain.Entities;

namespace PDD.NET.Persistence;

public static class FakeDataFactory
{
    public static IEnumerable<QuestionCategory> QuestionCategories => new List<QuestionCategory>()
    {
        new QuestionCategory() { Id = 1, Text = "Общие положения" },
        new QuestionCategory() { Id = 2, Text = "Дорожные знаки" },
        new QuestionCategory() { Id = 3, Text = "Дорожная разметка" },
        new QuestionCategory() { Id = 4, Text = "Специальные сигналы" },
        new QuestionCategory() { Id = 5, Text = "Светофор и Регулировщик" },
        new QuestionCategory() { Id = 6, Text = "Начало движения, маневрирование" }
    };

    public static IEnumerable<Question> Questions => new List<Question>()
    {
        // Общие положения
        new Question() { Id = 1, CategoryId = 1, ImageData = "https://storage.yandexcloud.net/pddlife/no_picture.png", Text = "Какие транспортные средства относятся к маршрутным транспортным средствам?" },
        new Question() { Id = 2, CategoryId = 1, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n19_1.jpg", Text = "Сколько проезжих частей имеет данная дорога?" },
        new Question() { Id = 3, CategoryId = 1, ImageData = "https://storage.yandexcloud.net/pddlife/no_picture.png", Text = "В каком случае водитель совершит вынужденную остановку?" },
        new Question() { Id = 4, CategoryId = 1, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n26_1.jpg", Text = "Выезд из двора или с другой прилегающей территории:" },
        new Question() { Id = 5, CategoryId = 1, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n33_1.jpg", Text = "Какой маневр намеревается выполнить водитель легкового автомобиля?" },

        // Дорожные знаки
        new Question() { Id = 6, CategoryId = 2, ImageData = "https://storage.yandexcloud.net/pddlife/no_picture.png", Text = "Какие из предупреждающих и запрещающих знаков являются временными?" },
        new Question() { Id = 7, CategoryId = 2, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n8_3.jpg", Text = "Какие из указанных знаков запрещают поворот налево?" },
        new Question() { Id = 8, CategoryId = 2, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n16_15.jpg", Text = "Кому Вы обязаны уступить дорогу при повороте налево?" },
        new Question() { Id = 9, CategoryId = 2, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n34_3.jpg", Text = "Остановка в зоне действия этого знака разрешена:" },
        new Question() { Id = 10, CategoryId = 2, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n16_2.jpg", Text = "В какой из дворов Вам можно въехать в данной ситуации?" },

        // Дорожная разметка
        new Question() { Id = 11, CategoryId = 3, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n1_8.jpg", Text = "Как Вам следует поступить при повороте направо?" },
        new Question() { Id = 12, CategoryId = 3, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n18_5.jpg", Text = "В данной ситуации Вы:" },
        new Question() { Id = 13, CategoryId = 3, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n12_5.jpg", Text = "Движение разрешается:" },
        new Question() { Id = 14, CategoryId = 3, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n36_5.jpg", Text = "Правая полоса предназначена для движения:" },
        new Question() { Id = 15, CategoryId = 3, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n32_5.jpg", Text = "О чем информирует Вас увеличение длины штриха прерывистой линии разметки?" },

        // Специальные сигналы
        new Question() { Id = 16, CategoryId = 4, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n3_6.jpg", Text = "При повороте направо Вы:" },
        new Question() { Id = 17, CategoryId = 4, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n19_6.jpg", Text = "Как Вы должны поступить в данной ситуации?" },
        new Question() { Id = 18, CategoryId = 4, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n36_6.jpg", Text = "Как следует поступить водителю легкового автомобиля при приближении автомобиля оперативной службы?" },
        new Question() { Id = 19, CategoryId = 4, ImageData = "https://storage.yandexcloud.net/pddlife/no_picture.png", Text = "В каких случаях необходимо уступить дорогу транспортному средству, имеющему нанесенные на наружные поверхности специальные цветографические схемы?" },
        new Question() { Id = 20, CategoryId = 4, ImageData = "https://storage.yandexcloud.net/pddlife/no_picture.png", Text = "Преимущество перед другими участниками движения имеет водитель автомобиля:" },

        // Светофор и Регулировщик
        new Question() { Id = 21, CategoryId = 5, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n31_13.jpg", Text = "Как Вам следует поступить при повороте налево?" },
        new Question() { Id = 22, CategoryId = 5, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n4_6.jpg", Text = "Каким транспортным средствам разрешено движение прямо?" },
        new Question() { Id = 23, CategoryId = 5, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n21_6.jpg", Text = "Разрешено ли Вам за перекрестком выехать на полосу с реверсивным движением?" },
        new Question() { Id = 24, CategoryId = 5, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n33_13.jpg", Text = "Как Вам следует поступить при повороте направо?" },
        new Question() { Id = 25, CategoryId = 5, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n7_6.jpg", Text = "Вам разрешается движение:" },

        // Начало движения, маневрирование
        new Question() { Id = 26, CategoryId = 6, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n14_9.jpg", Text = "Можно ли Вам развернуться в этом месте?" },
        new Question() { Id = 27, CategoryId = 6, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n22_8.jpg", Text = "По какой траектории Вам можно выполнить поворот налево?" },
        new Question() { Id = 28, CategoryId = 6, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n26_8.jpg", Text = "В каких направлениях Вам можно продолжить движение по второй полосе?" },
        new Question() { Id = 29, CategoryId = 6, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n6_7.jpg", Text = "Вы намерены продолжить движение по главной дороге. Обязаны ли Вы включить указатели левого поворота?" },
        new Question() { Id = 30, CategoryId = 6, ImageData = "https://storage.yandexcloud.net/pddlife/abm/n28_9.jpg", Text = "Разрешено ли водителю движение задним ходом для посадки пассажира на этом участке дороги?" },
    };

    public static IEnumerable<AnswerOption> AnswerOptions => new List<AnswerOption>()
    {
        
        new AnswerOption() { Id = 3, QuestionId = 1, Text = "Автобусы (в том числе школьные).", IsRight = false },
        new AnswerOption() { Id = 4, QuestionId = 1, Text = "Автобусы, троллейбусы, трамваи, используемые при осуществлении регулярных перевозок пассажиров и багажа, движущиеся по установленному маршруту с обозначенными местами остановок.", IsRight = true },
        new AnswerOption() { Id = 5, QuestionId = 1, Text = "Любые транспортные средства, перевозящие пассажиров и багаж, движущиеся по маршруту с остановками.", IsRight = false },

        new AnswerOption() { Id = 6, QuestionId = 2, Text = "Одну.", IsRight = false },
        new AnswerOption() { Id = 7, QuestionId = 2, Text = "Две.", IsRight = true },
        new AnswerOption() { Id = 8, QuestionId = 2, Text = "Четыре.", IsRight = false },

        new AnswerOption() { Id = 9, QuestionId = 3, Text = "Остановившись непосредственно перед пешеходным переходом, чтобы уступить дорогу пешеходу.", IsRight = false },
        new AnswerOption() { Id = 10, QuestionId = 3, Text = "Остановившись на проезжей части из-за технической неисправности транспортного средства.", IsRight = true },
        new AnswerOption() { Id = 11, QuestionId = 3, Text = "В обоих перечисленных случаях.", IsRight = false },

        new AnswerOption() { Id = 12, QuestionId = 4, Text = "Считается перекрестком равнозначных дорог.", IsRight = false },
        new AnswerOption() { Id = 13, QuestionId = 4, Text = "Считается перекрестком неравнозначных дорог.", IsRight = false },
        new AnswerOption() { Id = 14, QuestionId = 4, Text = "Не считается перекрестком.", IsRight = true },

        new AnswerOption() { Id = 15, QuestionId = 5, Text = "Обгон.", IsRight = false },
        new AnswerOption() { Id = 16, QuestionId = 5, Text = "Перестроение с дальнейшим опережением.", IsRight = true },
        new AnswerOption() { Id = 17, QuestionId = 5, Text = "Объезд.", IsRight = false },

        // Дорожные знаки
        new AnswerOption() { Id = 18, QuestionId = 6, Text = "Только установленные на переносных опорах.", IsRight = false },
        new AnswerOption() { Id = 19, QuestionId = 6, Text = "Имеющие желтый фон, а так же установленные на переносных опорах.", IsRight = true },
        new AnswerOption() { Id = 20, QuestionId = 6, Text = "Только установленные в местах производства дорожных работ.", IsRight = false },

        new AnswerOption() { Id = 21, QuestionId = 7, Text = "Только А.", IsRight = false },
        new AnswerOption() { Id = 22, QuestionId = 7, Text = "А и Б.", IsRight = false },
        new AnswerOption() { Id = 23, QuestionId = 7, Text = "А и В.", IsRight = true },
        new AnswerOption() { Id = 24, QuestionId = 7, Text = "Все.", IsRight = false },

        new AnswerOption() { Id = 25, QuestionId = 8, Text = "Только автобусу.", IsRight = false },
        new AnswerOption() { Id = 26, QuestionId = 8, Text = "Только легковому автомобилю.", IsRight = false },
        new AnswerOption() { Id = 27, QuestionId = 8, Text = "Обоим транспортным средствам.", IsRight = true },

        new AnswerOption() { Id = 28, QuestionId = 9, Text = "Только такси с включенным таксометром.", IsRight = false },
        new AnswerOption() { Id = 29, QuestionId = 9, Text = "Только транспортным средствам, с установленным опознавательным знаком «Инвалид».", IsRight = true },
        new AnswerOption() { Id = 30, QuestionId = 9, Text = "Всем перечисленным транспортным средствам.", IsRight = false },

        new AnswerOption() { Id = 31, QuestionId = 10, Text = "Повороты во дворы запрещены.", IsRight = false },
        new AnswerOption() { Id = 32, QuestionId = 10, Text = "Только во двор направо.", IsRight = true },
        new AnswerOption() { Id = 33, QuestionId = 10, Text = "Только во двор налево.", IsRight = false },
        new AnswerOption() { Id = 34, QuestionId = 10, Text = "В любой.", IsRight = false },

        // Дорожная разметка
        new AnswerOption() { Id = 35, QuestionId = 11, Text = "Перестроиться на правую полосу, затем осуществить поворот.", IsRight = false },
        new AnswerOption() { Id = 36, QuestionId = 11, Text = "Продолжить движение по второй полосе до перекрестка, затем повернуть.", IsRight = false },
        new AnswerOption() { Id = 37, QuestionId = 11, Text = "Возможны оба варианта действий.", IsRight = true },

        new AnswerOption() { Id = 38, QuestionId = 12, Text = "Должны остановиться у знака.", IsRight = false },
        new AnswerOption() { Id = 39, QuestionId = 12, Text = "Должны остановиться у стоп-линии.", IsRight = true },
        new AnswerOption() { Id = 40, QuestionId = 12, Text = "Можете при отсутствии других транспортных средств проехать перекресток без остановки.", IsRight = false },

        new AnswerOption() { Id = 41, QuestionId = 13, Text = "Только по траектории А.", IsRight = false },
        new AnswerOption() { Id = 42, QuestionId = 13, Text = "Только по траектории Б.", IsRight = true },
        new AnswerOption() { Id = 43, QuestionId = 13, Text = "По любой траектории из указанных.", IsRight = false },

        new AnswerOption() { Id = 44, QuestionId = 14, Text = "Любых автобусов.", IsRight = false },
        new AnswerOption() { Id = 45, QuestionId = 14, Text = "Всех автобусов и троллейбусов.", IsRight = false },
        new AnswerOption() { Id = 46, QuestionId = 14, Text = "Автобусов и троллейбусов, являющихся маршрутными транспортными средствами, школьных автобусов и легковых такси, а также велосипедистов.", IsRight = true },

        new AnswerOption() { Id = 47, QuestionId = 15, Text = "О начале зоны, где запрещены любые маневры.", IsRight = false },
        new AnswerOption() { Id = 48, QuestionId = 15, Text = "О начале опасного участка дороги.", IsRight = false },
        new AnswerOption() { Id = 49, QuestionId = 15, Text = "О приближении к сплошной линии разметки, разделяющей транспортные потоки попутных направлений.", IsRight = true },

        // Специальные сигналы
        new AnswerOption() { Id = 50, QuestionId = 16, Text = "Имеете право проехать перекресток первым.", IsRight = false },
        new AnswerOption() { Id = 51, QuestionId = 16, Text = "Должны уступить дорогу только пешеходам.", IsRight = false },
        new AnswerOption() { Id = 52, QuestionId = 16, Text = "Должны уступить дорогу автомобилю с включенными проблесковым маячком и специальным звуковым сигналом, а также пешеходам.", IsRight = true },

        new AnswerOption() { Id = 53, QuestionId = 17, Text = "Не должны уступать дорогу и продолжить движение.", IsRight = false },
        new AnswerOption() { Id = 54, QuestionId = 17, Text = "Должны уступить дорогу при необходимости.", IsRight = true },
        new AnswerOption() { Id = 55, QuestionId = 17, Text = "Должны остановиться и уступить дорогу полностью.", IsRight = false },

        new AnswerOption() { Id = 56, QuestionId = 18, Text = "Вам разрешается движение без остановки и обгона.", IsRight = false },
        new AnswerOption() { Id = 57, QuestionId = 18, Text = "Должны при необходимости уступить дорогу и затем продолжить движение.", IsRight = true },
        new AnswerOption() { Id = 58, QuestionId = 18, Text = "Должны остановиться и предоставить преимущество другим транспортным средствам.", IsRight = false },

        new AnswerOption() { Id = 59, QuestionId = 19, Text = "Только автомобилям такси и инвалидам.", IsRight = false },
        new AnswerOption() { Id = 60, QuestionId = 19, Text = "Только автомобилям оперативных служб, служб доставки и инвалидам.", IsRight = true },
        new AnswerOption() { Id = 61, QuestionId = 19, Text = "Любым транспортным средствам с опознавательными знаками и символами.", IsRight = false },

        new AnswerOption() { Id = 62, QuestionId = 20, Text = "Все транспортные средства, независимо от их назначения.", IsRight = false },
        new AnswerOption() { Id = 63, QuestionId = 20, Text = "Только такси и маршрутные автобусы.", IsRight = false },
        new AnswerOption() { Id = 64, QuestionId = 20, Text = "Автомобили оперативных служб и маршрутные транспортные средства.", IsRight = true },

        // Светофор и Регулировщик
        new AnswerOption() { Id = 65, QuestionId = 21, Text = "Можете продолжать движение прямо.", IsRight = true },
        new AnswerOption() { Id = 66, QuestionId = 21, Text = "Должны остановиться перед перекрестком и пропустить всех участников движения.", IsRight = false },
        new AnswerOption() { Id = 67, QuestionId = 21, Text = "Должны включить указатели поворота и уступить дорогу транспортным средствам, движущимся в поперечном направлении.", IsRight = false },

        new AnswerOption() { Id = 68, QuestionId = 22, Text = "Обязан уступить дорогу только велосипедистам.", IsRight = false },
        new AnswerOption() { Id = 69, QuestionId = 22, Text = "Можете продолжить движение без остановки, если не мешаете другим участникам движения.", IsRight = true },
        new AnswerOption() { Id = 70, QuestionId = 22, Text = "Должны остановиться и уступить дорогу только автомобилям со спецсигналами.", IsRight = false },

        new AnswerOption() { Id = 71, QuestionId = 23, Text = "Движение запрещено.", IsRight = false },
        new AnswerOption() { Id = 72, QuestionId = 23, Text = "Движение разрешено только при наличии сигнала светофора.", IsRight = false },
        new AnswerOption() { Id = 73, QuestionId = 23, Text = "Движение разрешено только при отсутствии других транспортных средств на полосе.", IsRight = true },

        new AnswerOption() { Id = 74, QuestionId = 24, Text = "Можете продолжить движение, включив указатель поворота.", IsRight = true },
        new AnswerOption() { Id = 75, QuestionId = 24, Text = "Должны остановиться и дождаться разрешающего сигнала.", IsRight = false },
        new AnswerOption() { Id = 76, QuestionId = 24, Text = "Можете продолжить движение, если дорожные знаки и разметка позволяют.", IsRight = false },

        new AnswerOption() { Id = 77, QuestionId = 25, Text = "Здесь запрещено движение для всех транспортных средств.", IsRight = false },
        new AnswerOption() { Id = 78, QuestionId = 25, Text = "Движение разрешено только для легковых автомобилей.", IsRight = false },
        new AnswerOption() { Id = 79, QuestionId = 25, Text = "Движение разрешено для всех транспортных средств, за исключением грузовых.", IsRight = true },

        // Начало движения, маневрирование
        new AnswerOption() { Id = 80, QuestionId = 26, Text = "Можно развернуться.", IsRight = true },
        new AnswerOption() { Id = 81, QuestionId = 26, Text = "Разворот запрещен.", IsRight = false },
        new AnswerOption() { Id = 82, QuestionId = 26, Text = "Можно развернуться, если перекресток свободен от других транспортных средств.", IsRight = false },

        new AnswerOption() { Id = 83, QuestionId = 27, Text = "По траектории А, если нет других транспортных средств.", IsRight = false },
        new AnswerOption() { Id = 84, QuestionId = 27, Text = "По траектории Б, если нет знаков и светофоров.", IsRight = true },
        new AnswerOption() { Id = 85, QuestionId = 27, Text = "По любой из указанных траекторий.", IsRight = false },

        new AnswerOption() { Id = 86, QuestionId = 28, Text = "Запрещено, так как маневрировать задним ходом запрещено.", IsRight = false },
        new AnswerOption() { Id = 87, QuestionId = 28, Text = "Разрешено, если это не создает помех другим участникам движения.", IsRight = true },
        new AnswerOption() { Id = 88, QuestionId = 28, Text = "Разрешено, но только в случае, если за этим участником движения нет других автомобилей.", IsRight = false },

        new AnswerOption() { Id = 89, QuestionId = 29, Text = "Необходимо включить указатели поворота.", IsRight = true },
        new AnswerOption() { Id = 90, QuestionId = 29, Text = "Можно продолжать движение без включения указателей.", IsRight = false },
        new AnswerOption() { Id = 91, QuestionId = 29, Text = "Не требуется включать указатели, если вы уже на главной дороге.", IsRight = false },

        new AnswerOption() { Id = 92, QuestionId = 30, Text = "Разрешено только для посадки и высадки пассажиров.", IsRight = false },
        new AnswerOption() { Id = 93, QuestionId = 30, Text = "Запрещено в любом случае.", IsRight = false },
        new AnswerOption() { Id = 94, QuestionId = 30, Text = "Разрешено, если это не мешает движению других транспортных средств.", IsRight = true },
    };
}
