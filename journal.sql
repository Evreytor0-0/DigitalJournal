-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Июн 04 2019 г., 21:12
-- Версия сервера: 10.1.38-MariaDB
-- Версия PHP: 7.3.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `journal`
--

-- --------------------------------------------------------

--
-- Структура таблицы `deti`
--

CREATE TABLE `deti` (
  `id` int(11) NOT NULL,
  `FIO` text NOT NULL,
  `DataRozhdeniya` date NOT NULL,
  `JournalId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `deti`
--

INSERT INTO `deti` (`id`, `FIO`, `DataRozhdeniya`, `JournalId`) VALUES
(1, 'первый ребенок иванова', '2019-05-07', 1),
(2, 'второй ребенок иванова', '2019-05-15', 1),
(3, 'первый ребенок ивананца', '2019-05-05', 5),
(4, 'второй ребенок ивананца', '2019-05-13', 5),
(17, 'первый ребенок петрова', '2019-04-29', 34),
(18, 'второй ребенок петрова', '2019-05-30', 34),
(19, 'третий ребенок петрова', '2019-06-02', 34);

-- --------------------------------------------------------

--
-- Структура таблицы `journal`
--

CREATE TABLE `journal` (
  `id` int(11) NOT NULL,
  `data_obrashcheniya` date NOT NULL,
  `data_postupleniya_dokumentov` date DEFAULT NULL,
  `id_sposoba_obrashcheniya` int(11) NOT NULL,
  `data_registracii` date NOT NULL,
  `fio_zayavitelya` text NOT NULL,
  `adres_zayavitelya` text NOT NULL,
  `id_uslugi` int(11) NOT NULL,
  `data_napravleniya_mvz` date DEFAULT NULL,
  `id_sposoba_naprvleniya` int(11) DEFAULT NULL,
  `data_uvedomleniya_o_priostanovlenii` date DEFAULT NULL,
  `id_rezultata` int(11) DEFAULT NULL,
  `data_prinyatiya_resheniya` date NOT NULL,
  `data_nachala` date DEFAULT NULL,
  `data_okonchaniya` date DEFAULT NULL,
  `n_dela` varchar(6) DEFAULT NULL,
  `id_prichiny_otkaza` int(11) DEFAULT NULL,
  `data_napravleniya_rezultata` date DEFAULT NULL,
  `id_specialista` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `journal`
--

INSERT INTO `journal` (`id`, `data_obrashcheniya`, `data_postupleniya_dokumentov`, `id_sposoba_obrashcheniya`, `data_registracii`, `fio_zayavitelya`, `adres_zayavitelya`, `id_uslugi`, `data_napravleniya_mvz`, `id_sposoba_naprvleniya`, `data_uvedomleniya_o_priostanovlenii`, `id_rezultata`, `data_prinyatiya_resheniya`, `data_nachala`, `data_okonchaniya`, `n_dela`, `id_prichiny_otkaza`, `data_napravleniya_rezultata`, `id_specialista`) VALUES
(1, '2019-03-12', '2019-03-12', 1, '2019-03-21', 'иванов иван иванович', 'гатчина', 1, '2019-03-12', 1, '2019-03-12', 1, '2019-03-12', '2019-04-01', '2021-02-28', NULL, 1, NULL, 1),
(4, '2019-03-12', '2019-03-12', 2, '2019-03-12', 'ивановский иван иванович', 'гатчина', 3, '2019-03-12', 2, '2019-03-12', 2, '2019-03-12', '2019-04-01', '2021-02-28', NULL, 2, NULL, 1),
(5, '2019-03-12', '2019-03-12', 3, '2019-03-12', 'иванец иван иванович', 'гатчина', 3, '2019-03-12', 3, '2019-03-12', 3, '2019-03-12', '2019-04-01', '2021-02-28', NULL, 3, NULL, 1),
(6, '2019-05-28', '2019-05-28', 1, '2019-05-28', 'esrewsrtwetrweew', 'qwewrwerewewr', 3, '2019-05-28', 2, '2019-05-28', 2, '2019-05-28', '2019-05-28', '2019-05-28', '123456', 2, '2019-05-28', 1),
(7, '2019-05-28', NULL, 2, '2019-05-28', '123123', '123', 3, NULL, NULL, NULL, NULL, '2019-05-28', NULL, NULL, NULL, NULL, NULL, 1),
(10, '2019-05-29', NULL, 1, '2019-05-29', '123123', '123', 1, NULL, NULL, NULL, NULL, '2019-05-29', NULL, NULL, NULL, NULL, NULL, 1),
(11, '2019-05-29', NULL, 1, '2019-05-29', '123123', '123', 1, NULL, NULL, NULL, NULL, '2019-05-29', NULL, NULL, NULL, NULL, NULL, 1),
(13, '2019-05-29', NULL, 2, '2019-05-29', '123123', 'гатчина', 1, NULL, NULL, NULL, NULL, '2019-05-29', NULL, NULL, NULL, NULL, NULL, 1),
(14, '2019-05-29', NULL, 1, '2019-05-29', '123123', '123', 1, NULL, NULL, NULL, NULL, '2019-05-29', NULL, NULL, NULL, NULL, NULL, 1),
(15, '2019-05-29', NULL, 1, '2019-05-29', '123123', '123', 1, NULL, NULL, NULL, NULL, '2019-05-29', NULL, NULL, NULL, NULL, NULL, 1),
(16, '2019-05-29', NULL, 1, '2019-05-29', 'esrewsrtwetrweew', 'qwewrwerewewr', 1, NULL, NULL, NULL, NULL, '2019-05-22', NULL, NULL, NULL, NULL, NULL, 1),
(17, '2019-05-29', NULL, 1, '2019-05-29', '123123', '123', 1, NULL, NULL, NULL, NULL, '2019-05-29', NULL, NULL, NULL, NULL, NULL, 1),
(18, '2019-05-29', NULL, 1, '2019-05-29', '123123', '123', 1, NULL, NULL, NULL, NULL, '2019-05-29', NULL, NULL, NULL, NULL, NULL, 1),
(19, '2019-05-29', NULL, 1, '2019-05-29', '123123', '123', 1, NULL, NULL, NULL, NULL, '2019-05-29', NULL, NULL, NULL, NULL, NULL, 1),
(20, '2019-05-29', NULL, 2, '2019-05-29', '123123', '123', 2, NULL, NULL, NULL, NULL, '2019-05-29', NULL, NULL, NULL, NULL, NULL, 1),
(21, '2019-05-29', NULL, 2, '2019-05-29', '123123', '123', 2, NULL, NULL, NULL, NULL, '2019-05-29', NULL, NULL, NULL, NULL, NULL, 1),
(22, '2019-05-29', NULL, 2, '2019-05-29', 'esrewsrtwetrweew', 'qwewrwerewewr', 1, NULL, NULL, NULL, NULL, '2019-05-29', NULL, NULL, NULL, NULL, NULL, 1),
(23, '2019-05-29', NULL, 2, '2019-05-29', 'esrewsrtwetrweew', 'qwewrwerewewr', 1, NULL, NULL, NULL, NULL, '2019-05-29', NULL, NULL, NULL, NULL, NULL, 1),
(24, '2019-05-29', '2019-05-29', 1, '2019-05-29', 'esrewsrtwetrweew', 'qwewrwerewewr', 1, NULL, NULL, NULL, NULL, '2019-05-29', NULL, NULL, NULL, NULL, NULL, 1),
(25, '2019-05-29', '2019-05-29', 1, '2019-05-29', 'esrewsrtwetrweew', 'qwewrwerewewr', 1, NULL, NULL, NULL, NULL, '2019-05-29', NULL, NULL, NULL, NULL, NULL, 1),
(26, '2019-05-29', NULL, 1, '2019-05-29', 'esrewsrtwetrweew', 'qwewrwerewewr', 2, '2019-05-29', NULL, NULL, NULL, '2019-05-29', NULL, NULL, NULL, NULL, NULL, 1),
(28, '2019-05-30', NULL, 1, '2019-05-30', 'esrewsrtwetrweew', 'qwewrwerewewr', 1, '2019-05-30', NULL, NULL, NULL, '2019-05-30', NULL, NULL, NULL, NULL, NULL, 1),
(31, '2019-05-30', NULL, 2, '2019-05-30', '123123', '123', 1, '2019-05-30', NULL, NULL, NULL, '2019-05-23', NULL, NULL, NULL, NULL, NULL, 1),
(34, '2019-05-30', '2019-05-30', 1, '2019-05-30', 'петров петр васильевич', 'гатчина', 1, '2019-05-30', NULL, NULL, 1, '2019-05-30', NULL, NULL, NULL, NULL, NULL, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `nachalo_uslugi`
--

CREATE TABLE `nachalo_uslugi` (
  `id` int(11) NOT NULL,
  `nachalo` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `nachalo_uslugi`
--

INSERT INTO `nachalo_uslugi` (`id`, `nachalo`) VALUES
(1, 'с начала месяца'),
(2, 'с начала года'),
(3, 'едоновременная');

-- --------------------------------------------------------

--
-- Структура таблицы `prichiny_otkaza`
--

CREATE TABLE `prichiny_otkaza` (
  `id` int(11) NOT NULL,
  `prichina` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `prichiny_otkaza`
--

INSERT INTO `prichiny_otkaza` (`id`, `prichina`) VALUES
(1, 'первая'),
(2, 'вторая'),
(3, 'третья'),
(13, '');

-- --------------------------------------------------------

--
-- Структура таблицы `specialist`
--

CREATE TABLE `specialist` (
  `id` int(11) NOT NULL,
  `fio` text NOT NULL,
  `login` varchar(10) NOT NULL,
  `password` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `specialist`
--

INSERT INTO `specialist` (`id`, `fio`, `login`, `password`) VALUES
(1, 'Корсакова Н.Ю.', '123', '202cb962ac59075b964b07152d234b70'),
(2, '', 'admin', '21232f297a57a5a743894a0e4a801fc3');

-- --------------------------------------------------------

--
-- Структура таблицы `sposoby_obrashcheniya`
--

CREATE TABLE `sposoby_obrashcheniya` (
  `id` int(11) NOT NULL,
  `sposoby` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `sposoby_obrashcheniya`
--

INSERT INTO `sposoby_obrashcheniya` (`id`, `sposoby`) VALUES
(1, 'ОСЗН'),
(2, 'второй'),
(3, 'третий');

-- --------------------------------------------------------

--
-- Структура таблицы `sposob_napravleniya_mvz`
--

CREATE TABLE `sposob_napravleniya_mvz` (
  `id` int(11) NOT NULL,
  `sposoby` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `sposob_napravleniya_mvz`
--

INSERT INTO `sposob_napravleniya_mvz` (`id`, `sposoby`) VALUES
(1, 'Межвед'),
(2, 'второй'),
(3, 'третий');

-- --------------------------------------------------------

--
-- Структура таблицы `status`
--

CREATE TABLE `status` (
  `id` int(11) NOT NULL,
  `status` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `status`
--

INSERT INTO `status` (`id`, `status`) VALUES
(1, 'Выдано'),
(2, 'второй'),
(3, 'третий');

-- --------------------------------------------------------

--
-- Структура таблицы `uslugi`
--

CREATE TABLE `uslugi` (
  `id` int(11) NOT NULL,
  `uslugi` varchar(30) NOT NULL,
  `id_nachala` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `uslugi`
--

INSERT INTO `uslugi` (`id`, `uslugi`, `id_nachala`) VALUES
(1, 'КТО', 1),
(2, 'одна', 2),
(3, 'вторая', 3);

-- --------------------------------------------------------

--
-- Структура таблицы `vidy_zaprosov`
--

CREATE TABLE `vidy_zaprosov` (
  `id` int(11) NOT NULL,
  `vid_zaprosa` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `vidy_zaprosov`
--

INSERT INTO `vidy_zaprosov` (`id`, `vid_zaprosa`) VALUES
(1, 'УПФР'),
(2, 'один'),
(3, 'второй'),
(4, 'третий'),
(5, 'четвертый');

-- --------------------------------------------------------

--
-- Структура таблицы `zaprosy`
--

CREATE TABLE `zaprosy` (
  `id` int(11) NOT NULL,
  `id_zhurnala` int(11) NOT NULL,
  `id_zaprosa` int(11) NOT NULL,
  `data_postupleniya_otveta` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `zaprosy`
--

INSERT INTO `zaprosy` (`id`, `id_zhurnala`, `id_zaprosa`, `data_postupleniya_otveta`) VALUES
(1, 1, 1, '2019-04-03'),
(2, 5, 3, '2019-05-17'),
(3, 4, 2, '2019-05-17'),
(4, 1, 4, NULL),
(5, 1, 5, '2019-05-13'),
(6, 28, 1, NULL),
(7, 28, 1, NULL),
(18, 31, 1, NULL),
(41, 34, 1, NULL),
(42, 34, 2, NULL);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `deti`
--
ALTER TABLE `deti`
  ADD PRIMARY KEY (`id`),
  ADD KEY `JournalId` (`JournalId`);

--
-- Индексы таблицы `journal`
--
ALTER TABLE `journal`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_uslugi` (`id_uslugi`),
  ADD KEY `id_sposoba_naprvleniya` (`id_sposoba_naprvleniya`),
  ADD KEY `id_specialista` (`id_specialista`),
  ADD KEY `id_rezultata` (`id_rezultata`),
  ADD KEY `id_sposoba_obrashcheniya` (`id_sposoba_obrashcheniya`) USING BTREE,
  ADD KEY `id_prichiny_otkaza` (`id_prichiny_otkaza`);

--
-- Индексы таблицы `nachalo_uslugi`
--
ALTER TABLE `nachalo_uslugi`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `prichiny_otkaza`
--
ALTER TABLE `prichiny_otkaza`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `specialist`
--
ALTER TABLE `specialist`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `login` (`login`);

--
-- Индексы таблицы `sposoby_obrashcheniya`
--
ALTER TABLE `sposoby_obrashcheniya`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `sposob_napravleniya_mvz`
--
ALTER TABLE `sposob_napravleniya_mvz`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `status`
--
ALTER TABLE `status`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `uslugi`
--
ALTER TABLE `uslugi`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_nachala` (`id_nachala`);

--
-- Индексы таблицы `vidy_zaprosov`
--
ALTER TABLE `vidy_zaprosov`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `zaprosy`
--
ALTER TABLE `zaprosy`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_zhurnala` (`id_zhurnala`),
  ADD KEY `id_zaprosa` (`id_zaprosa`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `deti`
--
ALTER TABLE `deti`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT для таблицы `journal`
--
ALTER TABLE `journal`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT для таблицы `nachalo_uslugi`
--
ALTER TABLE `nachalo_uslugi`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `prichiny_otkaza`
--
ALTER TABLE `prichiny_otkaza`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT для таблицы `specialist`
--
ALTER TABLE `specialist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `sposoby_obrashcheniya`
--
ALTER TABLE `sposoby_obrashcheniya`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `sposob_napravleniya_mvz`
--
ALTER TABLE `sposob_napravleniya_mvz`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `status`
--
ALTER TABLE `status`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `uslugi`
--
ALTER TABLE `uslugi`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `vidy_zaprosov`
--
ALTER TABLE `vidy_zaprosov`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `zaprosy`
--
ALTER TABLE `zaprosy`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `deti`
--
ALTER TABLE `deti`
  ADD CONSTRAINT `deti_ibfk_1` FOREIGN KEY (`JournalId`) REFERENCES `journal` (`id`);

--
-- Ограничения внешнего ключа таблицы `journal`
--
ALTER TABLE `journal`
  ADD CONSTRAINT `journal_ibfk_1` FOREIGN KEY (`id_sposoba_obrashcheniya`) REFERENCES `sposoby_obrashcheniya` (`id`),
  ADD CONSTRAINT `journal_ibfk_2` FOREIGN KEY (`id_uslugi`) REFERENCES `uslugi` (`id`),
  ADD CONSTRAINT `journal_ibfk_3` FOREIGN KEY (`id_sposoba_naprvleniya`) REFERENCES `sposob_napravleniya_mvz` (`id`),
  ADD CONSTRAINT `journal_ibfk_4` FOREIGN KEY (`id_specialista`) REFERENCES `specialist` (`id`),
  ADD CONSTRAINT `journal_ibfk_5` FOREIGN KEY (`id_rezultata`) REFERENCES `status` (`id`),
  ADD CONSTRAINT `journal_ibfk_6` FOREIGN KEY (`id_prichiny_otkaza`) REFERENCES `prichiny_otkaza` (`id`);

--
-- Ограничения внешнего ключа таблицы `uslugi`
--
ALTER TABLE `uslugi`
  ADD CONSTRAINT `uslugi_ibfk_1` FOREIGN KEY (`id_nachala`) REFERENCES `nachalo_uslugi` (`id`);

--
-- Ограничения внешнего ключа таблицы `zaprosy`
--
ALTER TABLE `zaprosy`
  ADD CONSTRAINT `zaprosy_ibfk_1` FOREIGN KEY (`id_zhurnala`) REFERENCES `journal` (`id`),
  ADD CONSTRAINT `zaprosy_ibfk_2` FOREIGN KEY (`id_zaprosa`) REFERENCES `vidy_zaprosov` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
