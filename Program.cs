using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.InputFiles;
using System.Data.SqlClient;

namespace ararararargibot
{
    class Program
    {
        private static string token { get; set; } = "2001759631:AAGOy4__9RJoNBmhp80XfOxZMjC9l_OhMTg";
        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }
        public DayOfWeek DayOfWeek { get; }


        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Пришло сообщение с текстом: {msg.Text}");

                switch (msg.Text)
                {

                    case "/help":
                    case "/help@ArarararagiBot":
                        {

                            await client.SendTextMessageAsync(msg.Chat.Id, "Помощь немощу, сам же догадаться не можешь интуитивно да:" + msg.From +
                                "\r\n/stick - рандомный стикер с Шинобу" +
                                "\r\n/pikcha - рандомная пикча с Шинобу" +
                                "\r\n/diplom - напишу за тебя диплом!" +
                                "\r\n/anekdot - рандомный анекдот из сборника, честно спизженного с просторов нашего необъятного" +
                                "\r\n/genshin_talents - материалы для возвышения талантов персонажей генша, доступные сегодня");
                            break;
                        }

                    case "/diplom":
                    case "/diplom@ArarararagiBot":
                        {
                            await client.SendTextMessageAsync(msg.Chat.Id, "Сори, у меня лапки.");
                            break;
                        }

                    case "/stick@ArarararagiBot":
                    case "/stick":
                        {
                            Random rnd1 = new Random();
                            int value1 = rnd1.Next(1, 12);
                            await client.SendTextMessageAsync(msg.Chat.Id, "Если очень попросишь, я добавлю в свой каталог яоя:)");
                            var stic = await client.SendStickerAsync(
                              chatId: msg.Chat.Id,
                              sticker: "https://cdn.tlgrm.app/stickers/34e/704/34e704f5-0115-3c1e-954e-74d2b180751d/192/" + value1 + ".webp",
                              replyToMessageId: msg.MessageId);
                            /*replyMarkup: GetButtons());*/
                            break;
                        }


                    case "/pikcha@ArarararagiBot":
                    case "/pikcha":
                        {
                            await client.SendTextMessageAsync(msg.Chat.Id, "Ну ты изврат");
                            string[] allfiles = Directory.GetFiles(@"C:/Users/Weabo/Downloads/shinobu");
                            Random rnd3 = new Random();
                            int value3 = rnd3.Next(0, allfiles.Length);

                            string path = @allfiles[value3];
                            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                var imag = await client.SendPhotoAsync(
                                chatId: msg.Chat.Id,
                                photo: new InputOnlineFile(fileStream));
                            }
                            break;

                        }

                    case "/anekdot@ArarararagiBot":
                    case "/anekdot":
                        {
                            await client.SendTextMessageAsync(msg.Chat.Id, "Рандомная юмореска");
                            string path = @"C:\Users\Weabo\Downloads\ANEKDOT.txt";
                            string text = File.ReadAllText(path, Encoding.UTF8);

                            string[] anekdots = text.Split(new string[] { "* * *" }, StringSplitOptions.None);
                            Random rnd4 = new Random();
                            int value4 = rnd4.Next(0, anekdots.Length);
                            await client.SendTextMessageAsync(msg.Chat.Id, anekdots[value4]);
                            break;

                        }

                    case "/genshin_talents@ArarararagiBot":
                    case "/genshin_talents":
                        {
                            DateTime date1 = DateTime.Now;
                            string date2 = date1.DayOfWeek.ToString();
                            if (date2 == "Monday")
                            {
                                await client.SendTextMessageAsync(msg.Chat.Id,
                                    "Понедельник.\r\n" +
                                    "\r\nМондштадт: учения/указания/философия о свободе.\r\nПерсонажи: Эмбер, Барбара, Сахароза, Кли, Диона, Тарталья, Элой.\r\n" +
                                    "\r\nЛи Юэ: учения/указания/философия о процветании.\r\nПерсонажи: Кэ Цин, Нин Гуан, Ци Ци, Сяо\r\n" +
                                    "\r\nИнадзума: учения/указания/философия о бренности.\r\nПерсонажи: Йоимия, Кокомия\r\n");
                            }
                            if (date2 == "Tuesday")
                            {
                                await client.SendTextMessageAsync(msg.Chat.Id,
                                    "Вторник.\r\n" +
                                     "\r\nМондштадт: учения/указания/философия о борьбе.\r\nПерсонажи: Беннет, Дилюк, Джинн, Мона, Ноэлль, Рейзор, Эола\r\n" +
                                    "\r\nЛи Юэ: учения/указания/философия о усердии.\r\nПерсонажи: Чун Юнь, Сян Лин, Гань Юй, Ху Тао, Кадзуха\r\n" +
                                    "\r\nИнадзума: учения/указания/философия о изяществе.\r\nПерсонажи: Аяка, Сара\r\n");
                            }
                            if (date2 == "Wednesday")
                            {
                                await client.SendTextMessageAsync(msg.Chat.Id,
                                    "Среда.\r\n" +
                                    "\r\nМондштадт: учения/указания/философия о поэзии.\r\nПерсонажи: Фишль, Кэйа, Лиза, Венти, Альбедо, Розария\r\n" +
                                    "\r\nЛи Юэ: учения/указания/философия о золоте.\r\nПерсонажи: Син Цю, Бэй Доу, Чжун Ли, Синь Янь, Янь Фей\r\n" +
                                    "\r\nИнадзума: учения/указания/философия о свете.\r\nПерсонажи: Саю, Сёгун Райдэн\r\n");
                            }
                            if (date2 == "Thursday")
                            {
                                await client.SendTextMessageAsync(msg.Chat.Id,
                                    "Четверг.\r\n" +
                                    "\r\nМондштадт: учения/указания/философия о свободе.\r\nПерсонажи: Эмбер, Барбара, Сахароза, Кли, Диона, Тарталья, Элой.\r\n" +
                                    "\r\nЛи Юэ: учения/указания/философия о процветании.\r\nПерсонажи: Кэ Цин, Нин Гуан, Ци Ци, Сяо\r\n" +
                                    "\r\nИнадзума: учения/указания/философия о бренности.\r\nПерсонажи: Йоимия, Кокомия\r\n");
                            }
                            if (date2 == "Friday")
                            {
                                await client.SendTextMessageAsync(msg.Chat.Id,
                                    "Пятница.\r\n" +
                                    "\r\nМондштадт: учения/указания/философия о борьбе.\r\nПерсонажи: Беннет, Дилюк, Джинн, Мона, Ноэлль, Рейзор, Эола\r\n" +
                                    "\r\nЛи Юэ: учения/указания/философия о усердии.\r\nПерсонажи: Чун Юнь, Сян Лин, Гань Юй, Ху Тао, Кадзуха\r\n" +
                                    "\r\nИнадзума: учения/указания/философия о изяществе.\r\nПерсонажи: Аяка, Сара\r\n");
                            }
                            if (date2 == "Saturday")
                            {
                                await client.SendTextMessageAsync(msg.Chat.Id,
                                    "Суббота.\r\n" +
                                    "\r\nМондштадт: учения/указания/философия о поэзии.\r\nПерсонажи: Фишль, Кэйа, Лиза, Венти, Альбедо, Розария\r\n" +
                                    "\r\nЛи Юэ: учения/указания/философия о золоте.\r\nПерсонажи: Син Цю, Бэй Доу, Чжун Ли, Синь Янь, Янь Фей\r\n" +
                                    "\r\nИнадзума: учения/указания/философия о свете.\r\nПерсонажи: Саю, Сёгун Райдэн\r\n");
                            }
                            if (date2 == "Sunday")
                            {
                                await client.SendTextMessageAsync(msg.Chat.Id, "Любые материалы на выбор.");
                            }
                            else
                            {
                                Console.WriteLine("wtf?!");
                            }
                            break;

                        }
                    case "/baza@ArarararagiBot":
                    case "/baza":
                        {
                            await client.SendTextMessageAsync(msg.Chat.Id, "Введите 1 или 2");
                            if (msg.Text == "1")
                            {
                                await client.SendTextMessageAsync(msg.Chat.Id, "Введено 1");
                            }
                            if (msg.Text == "2")
                            {
                                await client.SendTextMessageAsync(msg.Chat.Id, "Введено 2");
                            }
                            else
                            {
                                Console.WriteLine("не понял, что введено");
                            }
                            break;
                        }


                    default:

                        await client.SendTextMessageAsync(msg.Chat.Id, "/help для вызова моих команд");
                        break;


                }
            }
        }

    }
}

