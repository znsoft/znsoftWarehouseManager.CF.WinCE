Warehouse Manager - Складской учет
=================

Программа для работы со складской ИБД 1С через ВебСервис WinCE .CF

Visual Studio 2008, разработка ведется против общепринятых правил на русском языке (обфускация кода для англоговорящих :) )

Для работы желательно наличие DeviceApi.dll т.к в ней происходит работа со сканером ШК

при отсутствии этой .dll работа идет через буфер обмена на C900

 В режиме [STAThread]на ПК не работает с буфером обмена соответсвенно эмулировать сканер на ПК пришлось отдельным полем ввода по нажатию на клавиши CTRL+V

Проблеммы:


1. Необходимо перевести работу с хранением данных в формах списка товара из ListView в отдельный класс , дописав функции обработки и вывода данных




