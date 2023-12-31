# MovieSearch

![image](https://github.com/SergeyChagai/MovieSearch/assets/35423297/6da062d1-b428-4d57-9393-5c2920b6f574)

## Описание функционала

### Поиск кинофильмов:
Приложение позволяет пользователям искать кинофильмы по названию, жанру или имени актера.  
Результаты поиска отображаются ниже поисковой формы и включают информацию о найденных фильмах.

### Отображение информации о кинофильме:
Пользователи могут получить подробную информацию о выбранном кинофильме, включая данные об актерах и жанрах, связанных с фильмом.

### Хранение данных:
Данные о кинофильмах, актерах и жанрах хранятся в локальной SQLite базе данных.  
В последующих обновлениях при необходимости возможно добавление новых данных через приложение, а также обновления.

### Развертывание
1. Требования к системе:  
 • Приложение поддерживает устройства под управлением iOS и Android.  
 • Минимальные требования:  
Android: 5.0  
iOS: 8.0  
2. Упаковка и публикация приложения:  
	• iOS: https://learn.microsoft.com/en-us/xamarin/ios/deploy-test/app-distribution/app-store-distribution/publishing-to-the-app-store?tabs=windows.  
	• Android: https://learn.microsoft.com/en-us/xamarin/android/deploy-test/release-prep/?tabs=windows.  
3. [Использование DI Container:](MovieSearch/MovieSearch/DIContainer/AutoFacContainer.cs)
   
  	![image](https://github.com/SergeyChagai/MovieSearch/assets/35423297/ed068824-ae04-4517-9256-bf1940f2d6bf)

	• В приложении используется DI Container (Dependency Injection) от Autofac.  
	• Конфигурация DI Container - в сочетании с [CommonServiceLocator](MovieSearch/MovieSearch/DIContainer/ViewModelLocator.cs).
5. База данных и миграции:  
	• Приложение [использует](MovieSearch/MovieSearch/Models/ApplicationContext.cs) Entity Framework для работы с SQLite базой данных.  
	• Миграции базы данных:   
	Add-Migration  
	InitialCreate  
	Update-Database.
### Тестирование
Примеры тестовых сценариев:

![image](https://github.com/SergeyChagai/MovieSearch/assets/35423297/b7edd68f-568b-4743-bddc-44400fcf1d8e)

	a. Пользователь запускает приложение -> Пользователь на странице поиска ->  
 	Поля для ввода данных пусты -> Пользователь нажимает кнопку поиска ->  
  	Ниже кнопки поиска отображаются все фильмы в БД с данными об актерах и жанрах.

  ![image](https://github.com/SergeyChagai/MovieSearch/assets/35423297/455381b4-80ef-4068-aec4-d385e0c4b6df)

	b. Пользователь запускает приложение -> Пользователь на странице поиска ->  
 	Поля для ввода данных невалидны -> Пользователь нажимает кнопку поиска ->  
  	Ниже кнопки поиска не отображается ничего.

  ![image](https://github.com/SergeyChagai/MovieSearch/assets/35423297/cf47a8c8-07cd-4245-8d09-d5e15fc1be4a)

  ![image](https://github.com/SergeyChagai/MovieSearch/assets/35423297/47a398e0-309f-4811-95ff-43fa8225c772)

	c. Пользователь запускает приложение -> Пользователь на странице поиска ->  
 	Поля для ввода данных валидны -> Пользователь нажимает кнопку поиска ->  
  	Ниже кнопки поиска отображаются фильмы, соответствующие критериям поика с данными об актерах и жанрах.
		
### Код и комментарии
1. Единый стиль кода:  
	• Код приложения должен соответствовать Common C# code conventions.  
	• Оставляйте пустую строку между блоками логически связанного кода для улучшения читаемости.  
	• Стремитесь к тому, чтобы строки кода были не очень длинными, чтобы обеспечить легкость восприятия кода.  
	• Старайтесь использовать осмысленные имена переменных и методов, чтобы код был самодокументируемым.  
2. Минимальные комментарии:  
	• Комментарии добавлены там, где необходимо для лучшего понимания кода.  
	• Дополнительные пояснения по коду доступны в *вставить ссылку на файл*.  


### Примеры SQL-запросов

https://github.com/SergeyChagai/MovieSearch/blob/6613dfd6ef6c7869a6a8926101ee8f5afae40531/MovieSearch/MovieSearch/AllData.sql#L1-L5
https://github.com/SergeyChagai/MovieSearch/blob/6613dfd6ef6c7869a6a8926101ee8f5afae40531/MovieSearch/MovieSearch/MovieSearch.sql#L1-L13
