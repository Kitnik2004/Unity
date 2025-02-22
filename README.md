# Unity коды для себя любимого
Скрипты на Юнити для чемпионата "Профессионалы 2025" на 23.02.2025
 <hr>

[Скрипт на считывание джойстиков](Joystick.cs)

[Скрипт на движение ракеты](Movement.cs)

[Скрипт на ограничение свободы игрока](bordersOfWorld.cs)

[Скрипт на генерацию мусора в поле зрения игрока](musor.cs)

[Скрипт для переключения сцен по именам](SceneManager.cs)

<hr>

# Подсказки

debris - мусор

Чтобы создать скайбокс, нужно сначала создать материал

//Сохранение данных//

PlayerPrefs.SetInt("№", scores);

PlayerPrefs.SetString("№"+n, name);

scores = PlayerPrefs.GetInt("№");

name = PlayerPrefs.GetString("№"+n);


//Соприкосновение с коллайдерами: 

OnCollisionEnter(){}
