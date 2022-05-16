﻿using OnlineShopWebApp.Areas.Admin.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryProductsStorage : IProductsStorage
    {
        private List<Product> products = new List<Product>()
        {
            new Product("Достать ножи", 250, "На следующее утро после празднования 85-летия известного автора криминальных романов Харлана Тромби виновника торжества находят мёртвым. Налицо — явное самоубийство, но полиция по протоколу опрашивает всех присутствующих в особняке членов семьи, хотя, в этом деле больше заинтересован частный детектив Бенуа Блан. Тем же утром он получил конверт с наличными от неизвестного и заказ на расследование смерти Харлана. Не нужно быть опытным следователем, чтобы понять, что все приукрашивают свои отношения с почившим главой семейства, но Блану достаётся настоящий подарок — медсестра покойного, которая физически не выносит ложь.", "/images/knives_out.jpg", 130),
            new Product("1+1", 200, "Пострадав в результате несчастного случая, богатый аристократ Филипп нанимает в помощники человека, который менее всего подходит для этой работы, – молодого жителя предместья Дрисса, только что освободившегося из тюрьмы. Несмотря на то, что Филипп прикован к инвалидному креслу, Дриссу удается привнести в размеренную жизнь аристократа дух приключений.", "/images/1+1.jpg", 112),
            new Product("Веном",270,"Что если в один прекрасный день в тебя вселяется существо-симбиот, которое наделяет тебя сверхчеловеческими способностями? Вот только Веном – симбиот совсем недобрый, и договориться с ним невозможно. Хотя нужно ли договариваться?.. Ведь в какой-то момент ты понимаешь, что быть плохим вовсе не так уж и плохо. Так даже веселее. В мире и так слишком много супергероев! Мы – Веном!", "/images/venom.jpg", 112),
            new Product("Любовь от всех болезней", 200, "Роман Фобер – чудак и ипохондрик. Он никогда не был женат. Вся его жизнь сводится к тому, чтобы выискивать у себя симптомы страшных, на деле не существующих, болезней. Каждой находкой он стремится поделиться со своим единственным другом – доктором Димитрием Звенкой. Димитрий решает помочь Роману найти женщину и таким образом излечить его от постоянной ипохондрии, которая становится невыносимой.", "/images/love.jpg", 107),
            new Product("В поисках Немо", 260, "Рыба-клоун Марлин после трагической гибели жены в одиночку растит своего единственного сына Немо. Однажды любопытный Немо, чтобы доказать, что он уже взрослый, плывет в открытый океан и попадает в неприятности. Марлин отправляется на поиски сына.", "/images/nemo.jpg", 101),
            new Product("Люди в чёрном",200,"Они - самый большой секрет Земли. Они работают на неофициальное правительственное агентство, регулирующее деятельность инопланетян на Земле. Они - это лучшая, последняя и единственная линия защиты Земли от отбросов вселенной. Их работа секретна, их оружие совершенно, им нет равных, они не оставляют следов. Они - это Люди в черном.", "/images/mib.jpg", 98),
            new Product("Корпорация монстров", 300, "Склизкий гад в сливном бачке, мохнатый зверь, похожий на чудовище из «Аленького цветочка», гигантские мокрицы под кроватью — все они существуют на самом деле. Все, что им нужно — пугать детей, потому что из детских криков они получают электричество. Полнометражный мультфильм рассказывает о кризисах в мире монстров, их жизни. Но однажды вся мирная жизнь монстров оказывается под угрозой: в их мир попадает ребенок. А с детьми столько хлопот, что они могут довести даже монстров.", "images/monsters.jpg", 92),
            new Product("Дюна",290,"Наследник знаменитого дома Атрейдесов Пол отправляется вместе с семьей на одну из самых опасных планет во Вселенной — Арракис. Здесь нет ничего, кроме песка, палящего солнца, гигантских чудовищ и основной причины межгалактических конфликтов — невероятно ценного ресурса, который называется меланж. В результате захвата власти Пол вынужден бежать и скрываться, и это становится началом его эпического путешествия. Враждебный мир Арракиса приготовил для него множество тяжелых испытаний, но только тот, кто готов взглянуть в глаза своему страху, достоин стать избранным.", "/images/dune.jpg", 155),
            new Product("Час Пик",150,"В Лос-Анджелесе злодеи похищают малолетнюю дочь китайского консула, которую в Гонконге учил кунг-фу инспектор Ли. Консул вызывает Ли в Америку, чтобы тот принял участие в освобождении девочки. Агенты ФБР обратились к полиции с просьбой выделить им самого никчемного сотрудника, чтобы тот взял китайца на себя и показал ему достопримечательности, а главное, не позволил вмешиваться в их дела. Им оказывается самый болтливый полицейский Картер. Естественно, после ряда разногласий и недоразумений они объединяют усилия и всерьез берутся за вызволение заложницы.", "/images/rush_hour.jpg", 98),
            new Product("Город героев", 220, "Юный Хиро Хамада — прирожденный изобретатель и гений конструирования роботов. Вместе со старшим братом Тадаши они воплощают в жизнь самые передовые идеи в Техническом университете города будущего Сан-Франсокио. После серии загадочных событий друзья оказываются в центре коварного заговора. Отчаявшись, Хиро решает использовать веселого и добродушного экспериментального робота Бэймакса, перепрограммировав его в неуязвимую боевую машину.", "/images/heroes.jpg", 105),
            new Product("Пятый элемент", 200, "Каждые пять тысяч лет открываются двери между измерениями и темные силы стремятся нарушить существующую гармонию. Каждые пять тысяч лет Вселенной нужен герой, способный противостоять этому злу. XXIII век. Нью-йоркский таксист Корбен Даллас должен решить глобальную задачу - спасение всего рода человеческого. Зло в виде раскаленной массы, наделенной интеллектом, надвигается на Землю. Победить его можно, только лишь собрав воедино четыре элемента (они же стихии - земля, вода, воздух и огонь) и добавив к ним загадочный пятый элемент.", "/images/element.jpg", 126),
            new Product("Неоспоримый", 280, "Бывший чемпион мира по боксу во время визита в Россию случайно попадает в криминальную разборку, связанную с высшими правительственными чинами и против него фабрикуется ложное дело. Дорога домой будет долгой и трудной, проходящей через суровую российскую тюрьму...", "/images/undisputed.jpg", 98)
        };

        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
        public List<Product> TryGetByName(string productName)
        {
            var searchedProducts = new List<Product>();
            var keys = productName.Trim().Split(' ','-');
            foreach (var key in keys)
            {
                foreach(var product in products)
                {
                    if(product.Name.ToLower().Contains(key))
                    {
                        searchedProducts.Add(product);
                    }
                }
            }
            if (searchedProducts.Count == 0)
            {
                return null;
            }
            return searchedProducts;
        }

        public void Remove(int id)
        {
            var product = products.FirstOrDefault(product => product.Id == id);
            if (product != null)
            {
                products.Remove(product);
            }
        }
        public void Edit(Product product)
        {
            var existingProduct = TryGetById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name ?? existingProduct.Name;
                existingProduct.Cost = product.Cost;
                existingProduct.Duration = product.Duration;
                existingProduct.Description = product.Description;
            }
        }
        public void Create(AdminProductInfo adminProductInfo)
        {
            var defaultImagePath = "/images/projector.jpg";
            var product = new Product(adminProductInfo.Title,adminProductInfo.Cost,adminProductInfo.Description,defaultImagePath,adminProductInfo.Duration);
            products.Add(product);
        }
        public List<Product> GetPageContent(int? pageNumber)
        {
            var pageIndex = (pageNumber ?? 1) - 1;
            var pageSize = 4;
            var products = GetAll();
            products = products.Skip(pageSize * pageIndex).Take(pageSize).ToList();
            return (products);
        }
    }
}
