-- Active: 1694968636816@@127.0.0.1@3306@ekrushi

INSERT INTO roles(name) VALUES ('Shop owner');
INSERT INTO roles(name) VALUES ('Customer');
INSERT INTO roles(name) VALUES ('Supplier');
INSERT INTO roles(name) VALUES ('Shipper');
INSERT INTO roles(name) VALUES ('SubjectMatterExpert');


INSERT INTO userroles(userid,roleid) VALUES (1,1);
INSERT INTO userroles(userid,roleid) VALUES (4,1);
INSERT INTO userroles(userid,roleid) VALUES (2,2);
INSERT INTO userroles(userid,roleid) VALUES (3,2);
INSERT INTO userroles(userid,roleid) VALUES (11,3);
INSERT INTO userroles(userid,roleid) VALUES (12,3);
INSERT INTO userroles(userid,roleid) VALUES (6,4);
INSERT INTO userroles(userid,roleid) VALUES (7,4);
INSERT INTO userroles(userid,roleid) VALUES (8,5);
INSERT INTO userroles(userid,roleid) VALUES (9,5);

INSERT INTO stores(name,userid,addressid) VALUES  ("store 1",1,1);
INSERT INTO stores(name,userid,addressid) VALUES  ("store 2",4,5);

INSERT INTO suppliers(corporateid,userid) VALUES(8,11);
INSERT INTO suppliers(corporateid,userid) VALUES(9,12);

-- SHIPPERS DATA
-- INSERT INTO shippers(corporateid,userid) VALUES(4,6);
-- INSERT INTO shippers(corporateid,userid) VALUES(5,7);


INSERT INTO categories(title,image) VALUES('seeds',"/assets/seed.jpeg");
INSERT INTO categories(title,image) VALUES('Agriculture implements',"/assets/Agri Equipments.jpeg");
INSERT INTO categories(title,image) VALUES('fertilizers',"/assets/fertilizer.jpeg");
INSERT INTO categories(title,image) VALUES('pesticides',"/assets/pestisides.jpeg");
INSERT INTO categories(title,image) VALUES('cattel feed',"/assets/cattle feed.jpeg");
-- seeds
INSERT INTO products(title,description,image,categoryid) VALUES('oats seeds','For healthier and nutritiously growing food preferences, Oats are largely recommended by the topmost dieticians and nutritionists. Oats are the quintessential healthy food and make for an excellent and highly nutritious meal or even a snack. Being considered a superfood with an abundance of dietary fibres, beta-glucan, and several essential nutrients, Oats have become an everyday partner of every health-conscious individual. However, not everyone is familiar with the different kinds of Oats, having different generics, available in the market. Goodness and Wellness are the two common essences amongst all the different oats varieties. Let’s have a better understanding of the different types of oats, their key features, and nutrition components.','/assets/oat.jfif',1);
INSERT INTO products(title,description,image,categoryid)VALUES('wheat seeds','Wheat is the second most important staple food after rice consumed by 65% of the population in India and is likely to increase further due to changes in food habits. Wheat is mostly consumed in the form of ‘chapati’ in our country for which bread wheat is cultivated in nearly 95 per cent of the cropped area. ','/assets/wheat.jpg',1);
INSERT INTO products(title,description,image,categoryid) VALUES('corn seeds','Corn is one of the world’s most productive and dominant crops. It is grown extensively as food for both humans and livestock, as a biofuel, and as a crude material in industry. Corn is the third largest plant-based food source in the world.','/assets/corn.jfif',1);
INSERT INTO products(title,description,image,categoryid) VALUES('cluster Beans','Cluster beans, or Guar beans or Gawar beans, are annual legumes. They are a popular veggie in India. Cluster beans, also known as Cyamopsis tetragonoloba, are a member of the Fabaceae family. Plants like guar legumes live in symbiosis with nitrogen-fixing bacteria of the soil. This symbiotic action makes guar crucial in crop rotation cycles and replenishes the soil with essential nutrients for the next crop.','/assets/clusterbeans.jpeg',1);
INSERT INTO products(title,description,image,categoryid) VALUES('okra seeds','Product Description Number of seeds: 30 Seeds: Okra - Lady Finger Variety: Export Quality Seeds Germination: Min. 70% Plant to plant spacing: 20 cm Sunlight: Prefer Full Ease-of-care: Easy Best if grown directly from seeds Perfect for Indian climate; can be grown at Home in Pots and Gardens. Soil Preparation: Vegetable grows well in any fast-draining garden loam. It thrives in soils with a lot of organic matter, as long as they’re not too acidic. Incorporate 3” (8 cm) of good garden compost or well-aged manure into the bed at planting time. A slightly more alkaline soil than most vegetables (pH 6.5-7.5). Adaptability of this variety: Areas: State of Andhra Pradesh, Karnataka, TN, Kerala, MP, Maharastra, UP, Uttaranchal, Bihar, Jharkand, Haryana, Punjab, Delhi, Rajasthan, West Bengal, Chhatisgarh and North eastern states.','/assets/okra.webp',1);
INSERT INTO products(title,description,image,categoryid) VALUES('sunflower seeds','Sunflower Seeds is the perfect choice of Farmers for quality output. It requires around 4 kilograms of seeds to cultivate in one acre. Approximately yield of 5-6 quintals from one acre of Sunflower field. All the details above depends on the Fertility of Soil, Amount and duration of Water and pre-treatment of seeds before sowing. Also Climate is huge factor in quantity and quality of Every Yeild, Presoaking for 6-8 hours of Seeds before sowing is must. This enable to softening of thick outer shell for easy Germination.','/assets/sunflower.webp',1);
INSERT INTO products(title,description,image,categoryid) VALUES('pumpkin seeds','Pumpkin seeds are rich in vitamins and minerals like manganese and vitamin K, both of which are important in helping wounds heal. They also contain zinc, a mineral that helps the immune system fight bacteria and viruses. Pumpkin seeds are also an excellent source of: Phosphorus.','/assets/pumpkin.jpeg',1);
INSERT INTO products(title,description,image,categoryid) VALUES(' Rice Paddy Seeds','VISION CRAFTED Rice Paddy Seed for Sowing - Basmati seeds for farming | Basmati seeds for cultivation -1121 Variety (1 KG, Basmati 1121) Pusa Basmati 1121 is the first early maturing Basmati rice variety with seed to seed maturity of only 145 days and average yield of 4.5 to 5 tonne/ hectare. Pusa Basmati 1121 is a semi-dwarf (110-120 cm).Basmati rice variety with sturdy stem and plant height ranging from 110 - 120 cm. It takes140-145 days','/assets/ricepaddyseed.webp',1);
INSERT INTO products(title,description,image,categoryid) VALUES(' Bajra Seeds',' Its annual seed bajra when compared to fodder bajra will re-grow after each harvest (multi-cut), fast-growing cover crop with an extensive root system and heat-loving summer annual grass. It can grow 7-11 feet tall with long depending upon soil conditions, low water requirement, drought tolerance, slender leaves and no leaf blades. The leaves are similar to corn/maize but are shorter and sometimes wider. Fodder quality will be high due to low fibre content if cut frequently. Seed rate is 9-10 kg/acre, good seed germination like above 95 %; spacing is 0.5x1 feet for single seeds sow. Irrigation is 7–9 days depending upon soil conditions and suitable for anywhere climatic conditions in India. Give irrigation immediately after sowing and life/second irrigation on 3rd day from date of sowing then irrigate once in 10 days. Conduct on first harvest 60th days after sowing, then subsequent harvest 30-35 days once. It’s having 8.93-11.5 % of Crude Protein and Fat contains 4.81 %. Green fodder yield is 27-30 t/acre/yr. Used primarily for pastures, grazing, green chop, silage and hay. Good green fodder to Cow, Buffalo, Goat and Sheep. Improving milk yield and body weight also.','/assets/bajra-seeds.webp',1);
INSERT INTO products(title,description,image,categoryid) VALUES(' Muli Seeds',' Long Radish Seeds for Home Garden | Farming | Vegetable | Hybrid | Kitchen | Planting | Terrace | Balcony | Eating | Mula | Mulia | Mooli | Muli | Mullangi | White Mooli - 10 Gram : 834 Seed How fast do radishes grow from a seed? : Plant radishes from seeds in early spring, four to six weeks before the average date of your last spring frost. In fall, plant four to six weeks before the first expected fall frost. Radish seedlings usually take three to four days to sprout, but some varieties take a few weeks. What time of year do you plant radishes? : Radishes do best when grown in cooler conditions, and are tolerant of cold weather. Loosen soil before planting at least six inches deep, a foot or more for long types. Plant seeds from April through early May, and again in August. Are radishes easy to grow? : Radishes are quick, easy and fun to grow from seed, ready to eat in as little as four weeks. These compact plants can be grown in even the smallest of gardens and are great gap-fillers on the veg plot. Sow small batches every few weeks for harvesting throughout summer, to add a crunchy tang to your salads. Best Suitable for Terrace Gardening, Grow bag cultivation, Kitchen Gardening, Terrace Gardening & Roof Top Balcony Gardening. Organic Vegetable seeds, Best for planting throughout the year. Best in class germination, Suitable for all Seasons, Fresh Seeds. Easy to Grow - Can be grown in indian climate/weather conditions. Do not use for food, feed, or oil purposes, Seeds are only for Gardening Purpose. Very showy High Impact Bedding all season Vegetables for all beautiful gardens and landscape to keep your garden noticed by all.High Quality Seeds with Germination rate of above 90%.','/assets/muli.webp',1);


-- Agricultural Implements
INSERT INTO products(title,description,image,categoryid) VALUES('Hand Sprayer','User instruction: Pour  fluid into the Garden sprayer and with the help of air compressor, pump-in until the pressure fills and then adjust the nozzle for either fine mist or for pressure jet. This sprayer has dual flow i.e Mist flow and Pressure Jet flow and the sprayer has a capacity of 2 litres. Can be used for multiple purposes. . This lawn sprayer is not suitable for corrosive or acidic solutions. Adjustable brass nozzle. . The high-quality brass nozzle can adjust the intensity of the water spray from direct injection to fine mist spray. An arthritis-friendly easy grip handle, efficient pump and trigger lock make continuous spraying less straining Spray plants and more - plants need fertilizer, pesticides, insecticides and even neem oil, and of course water.','/assets/handsprayer.jpg',2);
INSERT INTO products(title,description,image,categoryid) VALUES('Garden Scissors','Garden Sharp Cutter Pruners Scissor with grip-handle This reliable tree Pruner is ideal for all varieties of general pruning tasks. Its cutting ability is stronger than ordinary pruning shears. Be a good partner for your garden work. Sharp and reliable can easily for most of the lightweight pruning work, also can help your to do some heavy duty for less than 3/4"" diameter size tree branches. ERGONOMIC DESIGN Lightweight metal ergonomic handles with rubber cushioning for a comfortable yet solid grasp. Features: 1.Premium durable, sharp & reliable bypass pruning shear is a must-have for any gardener! 2.Material: stainless steel (handle material pp plastic); 3.Prune your favorite plants, flowers, bushes and hedges with ease - smoothly cut through stems, branches, roots, vines and more. Our blade use non-stick coating for rust resistant, lower friction when cutting and prevent the blade gumming up with sap or debris. 4.The forged stainless steel handles of the pruning shear are ergonomically designed to always be comfortable, even after long hours in the garden. Handles feature a non-slip rubber grip as well as an easy-to-use security lock. 5.Long-lasting, Dependable and Reliable','/assets/gardenscissors.webp',2);
INSERT INTO products(title,description,image,categoryid) VALUES('Hose pipe',' PVC HOSE PIPES, Used For Gardening , Car Washing , Bike Washing , Pet Bath , Floor Clean , Construction , Agricultural, Sprinkling , ETC. Our Long Lasting Hose Pipes Are Made With Premium And High-Quality PVC & Abrasion Resistant Materials And Are Designed For Both Hot And Cold Conditions. Our Hose Pipes Comes With Accessories To Make Them User Friendly And For Perfect Gardening Experience. Made With ?? In INDIA','/assets/Hosepipe.jpeg',2);
INSERT INTO products(title,description,image,categoryid) VALUES('Balwan Battery Sprayer ','You can use the Balwaan Battery sprayer for agriculture, sanitizer, chemicals, farming, gardening, and many more purposes. This sprayer pump is 12 volt 8 ampere. It will get fully charged in 3-4 Hours. With a fully charged battery, you can use this 18-litre tank 15-20 times. We give our customers the best quality pump. No manual efforts are required to create pressure. Continuous & Mist spray. This sprayer has multiple applications and is widely used in agriculture, horticulture, sericulture, plantations, forestry, and gardens. Note - Damage parts not covered in the warranty','/assets/batterysprayer.webp',2);
INSERT INTO products(title,description,image,categoryid) VALUES('Mulch Film ','Blocks sunlight and prevent weed seed germination without chemicals Protect soil from water loss due to evaporation. Good for water conservation Increases crop yield due to low pest attack Material : LLDPE Plastic. Quality : 30 Micron, Usage: Weed Prevention','/assets/mulch-film.jpg',2);
INSERT INTO products(title,description,image,categoryid) VALUES('ShedNet ','This 75 % UV stabilization protect to direct sun rays. longer life durability. Sun protection and dust protection netting material usable: - usable in garden and farm plants for UV sun protection. Usable in window, gallery and balcony cover. usable for car cover for dust protection and sun protection. usable industrial machinary covers. Usable for stop working construction part. Usable for home roof shade to protect sun rays. Usable for indoor outdoor curtain. item color is green but can be changed normally light green or dark green.','/assets/shednet.webp',2);
INSERT INTO products(title,description,image,categoryid) VALUES('Pickaxe ','Strong Wooden Handle Made for rough use and long lasting Alloy Steel, Hardened and Tempered Ideal for Digging','/assets/pickaxe.jpg',2);
INSERT INTO products(title,description,image,categoryid) VALUES('Weeding Hook ','This Agricultural and Gardening crop cutting tool is specially designed to remove weed and grass. An excellent product with sharp zigzag teeth For smooth Cutting Performance.','/assets/weedinghook.jpg',2);
INSERT INTO products(title,description,image,categoryid) VALUES('Axe ','ERGONOMIC DESIGN: Our Hatched is Designed with a Shock Absorbing Anti Slip Grip, Cold Resistant Ergonomic Shaped Fiberglass Handle which will reduce the strain on your hand, resists slipping and adds comfort.
EASY STORAGE: The head comes with a Rubber Protective Sheath for safe storage and transport. After use, simply apply the rubber protective cover and hang the Hatchet from the hole that is featured for easy and convenient storage.
DURABLE CONSTRUCTION: The Forged Carbon Steel Heat Treated head which improves its density and makes the axe more durable produces smooth and quick splits and stays sharp longer than traditional axes. You can count on this Hand Axe to deliver superior, long lasting performance.','/assets/axe.jpg',2);
INSERT INTO products(title,description,image,categoryid) VALUES('Favda ','Agriculture Tool Primarily Used for Digging.
It Contain a Blade Attached with a Long Handle.
The Handle is Very Strong & Spade were Made with Sharper Tips of Metal.
Heavy Duty Gardening Spade with Strong Wooden Handle Suitable for digging, balancing, forming hard/raw ground soil
like as a kassi fawda khurpi spade or hor shovel','/assets/favda.jpg',2);


-- FERTILIZERS
INSERT INTO products(title,description,image,categoryid) VALUES('Urea','Urea is the chief nitrogenous end product of the metabolic breakdown of proteins in all mammals and some fishes. It occurs not only in the urine of mammals but also in their blood, bile, milk, and perspiration.','/assets/UREA.png',3);
INSERT INTO products(title,description,image,categoryid) VALUES('12-32-16','This is one of the highest nutrients containing NPK complex fertiliser with total nutrients of 60%
Nitrogen and Phosphate are available in the ratio 1:2.6 as in the case of DAP, but in Mahadhan 12:32:16 also contains 16% Potash additionally
Mahadhan 12:32:16 helps the young plants to grow faster, even under adverse soil or climatic condition','/assets/12-32-16.jpeg',3);
INSERT INTO products(title,description,image,categoryid) VALUES('10-26-26','Improves nutrient availability & reduce nutrient loss.
It increases crop yield by 10% to 15%.
Increases CEC and nutrient holding capacity of soil.
Rich in organic carbon and mineral substances essential to plant growth
Retains water soluble fertilisers and releases in root zones as needed
Increases plant uptake of nutrients
','/assets/10-26-26.jpeg',3);
INSERT INTO products(title, description, image, categoryid) VALUES('Diammonium Phosphate (DAP)','Diammonium phosphate contains nitrogen and phosphorus, making it suitable for a wide range of crops. It promotes healthy plant growth.','/assets/dap.jpeg',3);
INSERT INTO products(title, description, image, categoryid) VALUES('Potassium Sulfate','Potassium sulfate contains potassium and sulfur, benefiting fruits and vegetables. It improves overall plant health and yield.','/assets/potassiumsulphate.jpeg',3);
INSERT INTO products(title, description, image, categoryid) VALUES('Iron Chelates','Iron chelates are used to correct iron deficiencies in plants, particularly in alkaline soils. They enhance chlorophyll production.','/assets/chelatediron.jpeg',3);
INSERT INTO products(title, description, image, categoryid) VALUES('Zinc Sulfate','Zinc sulfate provides essential zinc for plant health and development. It is crucial for various enzymatic processes.','/assets/zincsulphate.jpeg',3);
INSERT INTO products(title, description, image, categoryid) VALUES('Calcium Nitrate','Calcium nitrate provides calcium and nitrogen, benefiting fruiting crops and overall plant health.','/assets/calciumnitrate.jpeg',3);
INSERT INTO products(title, description, image, categoryid) VALUES('Boron Fertilizer','Boron fertilizer is used to prevent boron deficiency in crops like broccoli and cauliflower.','/assets/boron.jpeg',3);
INSERT INTO products(title, description, image, categoryid) VALUES('Liquid Seaweed Fertilizer','Liquid seaweed fertilizer contains trace elements and growth-promoting hormones, suitable for a variety of crops.','/assets/ls.jpeg',3);




-- pestisides
INSERT INTO products(title,description,image,categoryid) VALUES('Admire','Admire contains Imidacloprid, one of the world best selling insecticides. It is a systemic insecticide belonging to the chemical class of neonicotinoids and is very effective against various insect pests','/assets/mira.webp',4);
INSERT INTO products(title,description,image,categoryid) VALUES('Rogor','It can be applied by mixing 1-2 ml with a liter of water and spraying over the concerned plants.
Rogor Is 30% EC Formulation Of Dimethoate
It Is Highly Effective In Controlling The Sucking And Caterpillar Pests
It Is highly Compatible With Other Insecticides And Fungicides','/assets/Rogor.jpeg',4);
INSERT INTO products(title,description,image,categoryid) VALUES('Antracol',
'Antracol contains Propineb, a contact fungicide with broad spectrum activity against various diseases of rice, chilli, grapes, potato and other vegetables and fruits. Propineb is a polymeric zinc-containing dithiocarbamate. Due to the release of zinc, the application of Antracol results in greening effect on the crop and subsequent improvement in quality of produce.','/assets/antracol.jpeg',4);
INSERT INTO products(title,description,image,categoryid) VALUES('Avatar','Avtar is a Broad-spectrum fungicide, which controls large number of diseases with its multisite and systemic action. Avatar is an effective fungicide that is useful for all crops and vegetables.','/assets/Avtar.jpeg',4);
INSERT INTO products(title,description,image,categoryid) VALUES('coragen','
Coragen® insecticide is an anthranilic diamide Broad Spectrum insecticide in the form of a suspension concentrate.
Coragen® insecticide is particularly active on Lepidopteran insect pests, primarily as a larvicide.
Coragen® insecticide is powered by active ingredient Rynaxypyr® active which has a unique mode of action that controls pests resistant to other insecticides.
Coragen® insecticide is selective & safe for non-target arthropods and conserves natural parasitoids, predators and pollinators.','/assets/coragen.jpeg',4);
INSERT INTO products(title,description,image,categoryid) VALUES('Zyme','V-Zyme Sport is specially designed for turf , its a unique formulation of micronutrients with amino acid, growth-supporting co-factors and biostimulator, consisting of various minerals suspended in amino acids.
The micronutrients are used in such a peculiar form that ensures the bioavailability of these micronutrients to the maximum extent. Such bioavailability of these micronutrients is rarely seen in any other products available in the market.','/assets/zyme.jpeg',4);
INSERT INTO products(title,description,image,categoryid) VALUES('Melody','Melody Duo is a modern fungicide containing the two active ingredients Iprovalicarb and Propineb.','/assets/Melody.jpeg',4);
INSERT INTO products(title,description,image,categoryid) VALUES('Goal','Goal® contains oxyfluorfen as active ingredient which belongs to diphenyl ether.
As pre-emergence, Goal® forms a chemical barrier on the soil surface and affects weed plants through direct contact at emergence.
Actively growing plants are very susceptible to Goal® as post-emergence action','/assets/Goal.jpeg',4);
INSERT INTO products(title,description,image,categoryid) VALUES('Targa-super','Targa Super is selective, systemic herbicide of Aryloxyphenoxy-propionates group. It is used to control narrow leaf weeds in broad leaf crops.','/assets/targa-super.png',4);
INSERT INTO products(title,description,image,categoryid) VALUES('Profex','Profex Super can be used for lerva type insect killing. It can be used for all types of vegetables, fruits, and flowers. Also, use for home garden plants excellent result.','/assets/profex.jpeg',4);

-- catelfeed
INSERT INTO products(title,description,image,categoryid) VALUES('Sarki pend','Perfect mixture
Quality examined
Completely organic
Lower price
Free from damage by water','/assets/sarki pend.jpeg',5);

INSERT INTO products(title,description,image,categoryid) VALUES('Kandi','This useful to cow, Goat, buffawlo. This is one of the most important feed for animal','/assets/kandi.jpeg',5);
INSERT INTO products(title,description,image,categoryid) VALUES('Bhusa','This useful to cow, Goat, buffawlo. This is one of the most important feed for animal','/assets/bhusa.jpeg',5);
INSERT INTO products(title,description,image,categoryid) VALUES('Milkgen','Form: 3mm roasted pellets
Crude protein: 24%* (min)
Crude fat: 4%* (min)
Crude fiber: 10%* (max)
Moisture: 11%* (max)','/assets/milkgen10000.png',5);
INSERT INTO products(title,description,image,categoryid) VALUES('Pragati','Dairy Gold is a balanced source of essential nutrients required for body maintenance, growth and milk production. It is manufactured using good quality grains, oil cakes/ meals, brans, molasses, com- mon salt, minerals and vitamins. It is comparatively cheaper and highly palatable to the animals.','/assets/Pragati.png',5);
INSERT INTO products(title,description,image,categoryid) VALUES('Buffgen4000','Form: 3mm roasted pellets
Crude protein: 22%* (min)
Crude fat: 5%* (min)
Crude fiber: 12%* (max)
Moisture: 11%* (max)
','/assets/buffgen.png',5);
INSERT INTO products(title,description,image,categoryid) VALUES('Dairy Gold','Dairy Gold is a balanced source of essential nutrients required for body maintenance, growth and milk production. It is manufactured using good quality grains, oil cakes/ meals, brans, molasses, com- mon salt, minerals and vitamins. It is comparatively cheaper and highly palatable to the animals.','/assets/dairygold.webp',5);
INSERT INTO products(title,description,image,categoryid) VALUES('Kapila Dairy Special','Contains By Pass Protein & Fat to increase the absorption of fats & protein.
Contains 3.5% Fat, 25-28% Crude Protein and other minerals.
Kapila Dairy Special (By Pass) is beneficial for cows of foreign breed.
Recommended for any dairy breed of average weight yielding large quantity of milk.','/assets/dairy-special-small.jpg',5);
INSERT INTO products(title,description,image,categoryid) VALUES('Amul Nutri Rich','Amul Nutri Rich, Cattle Feed - Bis Type-1, 50 Kg Bag is a feed that is rich in protein and minerals. It is specially designed for cows that are pregnant or lactating. The cows will produce milk and their offspring will be healthier. The cows will also be able to produce more milk for longer periods of time. Bis Type-1 is a quality cattle feed that has been developed to provide optimum nutrition for dairy cattle. The ingredients in this feed are carefully selected to promote rapid growth and healthy conditions for the animals. The result is a product that not only improves the animals quality of life, but also the quality of the milk and dairy products that are produced.','/assets/nutririch.webp',5);
INSERT INTO products(title,description,image,categoryid) VALUES('KAPILA HI PRO','A feed that has just right amount of protein (24%) and fat (4%), Manufactured under International Organisation Standards. It is made of completely natural products that will help your cattle to give milk to its full potential and remain healthy for longer period of time.','/assets/hi-pro.jpg',5);


-- product details
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(1,120,1000,'1kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(1,240,1000,'2kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(2,300,1000,'10kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(2,550,1000,'25kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(3,2500,1000,'1kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(4,250,1000,'1kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(4,500,1000,'2kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(5,120,1000,'500gm',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(5,210,1000,'1kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(6,450,1000,'1kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(6,600,1000,'1.5kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(7,220,1000,'1kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(7,400,1000,'2kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(8,1400,1000,'1kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(8,2800,1000,'2kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(9,120,1000,'1kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(9,240,1000,'2kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(10,1200,1000,'1kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(10,2400,1000,'2kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(11,250,1000,'S',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(12,400,1000,'S',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(12,800,1000,'M',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(13,1050,1000,'10m',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(13,2000,1000,'20m',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(14,3000,1000,'16L',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(14,4000,1000,'20L',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(15,2500,1000,'10m',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(15,5000,1000,'25m',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(16,320,1000,'15m',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(16,600,1000,'30m',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(17,2500,1000,'L',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(18,250,1000,'S',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(18,350,1000,'M',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(19,1610,1000,'S',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(20,400,1000,'S',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(21,150,1000,'25kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(21,270,1000,'50kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(22,250,1000,'25kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(22,500,1000,'50kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(23,700,1000,'25kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(23,1400,1000,'25kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(24,600,1000,'25kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(24,1200,1000,'50kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(25,550,1000,'25kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(25,1150,1000,'50kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(26,150,1000,'1kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(27,300,1000,'2kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(28,750,1000,'10kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(28,1400,1000,'50kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(29,650,1000,'5kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(29,6500,1000,'50kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(30,600,1000,'25kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(30,1150,1000,'50kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(31,240,1000,'100ml',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(31,500,1000,'250ml',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(32,120,1000,'100ml',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(32,220,1000,'220ml',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(33,250,1000,'100gm',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(33,325,1000,'250kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(34,120,1000,'100gm',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(34,240,1000,'200gm',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(35,1050,1000,'25ml',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(35,1600,1000,'50ml',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(36,120,1000,'100gm',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(36,200,1000,'200gm',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(37,250,1000,'100gm',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(37,500,1000,'250gm',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(38,320,1000,'150ml',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(38,150,1000,'75ml',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(39,250,1000,'100ml',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(39,300,1000,'150ml',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(40,300,1000,'150ml',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(40,600,1000,'250ml',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(41,700,1000,'25kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(41,1700,1000,'50kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(42,800,1000,'25kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(42,1610,1000,'50kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(43,700,1000,'25kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(43,1400,1000,'50kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(44,800,1000,'25kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(44,1600,1000,'50kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(45,850,1000,'25kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(45,1700,1000,'50kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(46,1200,1000,'25kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(46,2400,1000,'50kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(47,800,1000,'25kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(47,1600,1000,'50kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(48,1000,1000,'25kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(48,2000,1000,'50kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(49,700,1000,'25kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(49,1400,1000,'50kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(50,900,1000,'25kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(50,1800,1000,'50kg',2);
 
 -- Product review

INSERT INTO productreview(productid,customerid,rating,review) VALUES (1,2,4.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (1,3,2,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (2,2,3,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (2,3,4,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (3,2,4.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (3,3,3.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (4,2,2.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (4,3,4,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (5,2,5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (5,3,4,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (6,2,2,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (6,3,2,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (7,2,4.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (7,3,5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (8,2,1,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (8,3,4,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (9,2,4,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (9,3,4,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (10,2,3,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (10,3,3.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (11,2,2.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (11,3,1.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (12,2,2.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (12,3,3.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (13,2,4.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (13,3,5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (14,2,4,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (14,3,4,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (15,2,3,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (15,3,4.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (16,2,3.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (16,3,3.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (17,2,1.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (17,3,4,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (18,2,4,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (18,3,4.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (19,2,1.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (19,3,2.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (20,2,2.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (20,3,3.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (21,2,4.5,'Nice Product');
INSERT INTO productreview(productid,customerid,rating,review) VALUES (21,3,4.5,'Nice Product');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (22, 2, 3.0, 'Average quality');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (22, 3, 4.0, 'Better than expected');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (23, 2, 5.0, 'Excellent product!');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (23, 3, 4.5, 'Very satisfied');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (24, 2, 3.5, 'Decent quality, but could be better');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (24, 3, 4.0, 'Satisfactory purchase');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (25, 2, 2.5, 'Not very pleased with the product');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (25, 3, 3.0, 'Could be improved');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (26, 2, 4.0, 'Good quality product');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (26, 3, 4.5, 'Satisfied with the purchase');


INSERT INTO productreview(productid, customerid, rating, review) VALUES (27, 2, 3.5, 'Decent product for the price');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (27, 3, 4.0, 'Met my expectations');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (28, 2, 4.0, 'Above-average quality');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (28, 3, 3.5, 'Fair purchase');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (29, 2, 2.0, 'Not as expected');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (29, 3, 2.5, 'Could be improved');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (30, 2, 4.5, 'Outstanding quality!');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (30, 3, 5.0, 'Impressed with the product');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (31, 2, 3.0, 'Average product');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (31, 3, 3.5, 'Met my basic requirements');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (32, 2, 4.0, 'Good value for money');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (32, 3, 4.5, 'Satisfied with the purchase');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (33, 2, 3.0, 'Average product');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (33, 3, 3.5, 'Met my basic requirements');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (34, 2, 4.0, 'Good value for money');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (34, 3, 4.5, 'Satisfied with the purchase');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (35, 2, 2.5, 'Below expectations');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (35, 3, 3.0, 'Could be improved');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (36, 2, 4.0, 'Good quality product');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (36, 3, 4.5, 'Satisfied with the purchase');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (37, 2, 3.5, 'Decent product for the price');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (37, 3, 4.0, 'Met my expectations');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (38, 2, 2.0, 'Not as expected');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (38, 3, 2.5, 'Could be improved');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (39, 2, 4.5, 'Outstanding quality!');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (39, 3, 5.0, 'Impressed with the product');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (40, 2, 3.0, 'Average product');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (40, 3, 3.5, 'Met my basic requirements');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (41, 2, 4.0, 'Good value for money');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (41, 3, 4.5, 'Satisfied with the purchase');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (42, 2, 2.5, 'Below expectations');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (42, 3, 3.0, 'Could be improved');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (43, 2, 4.0, 'Good quality product');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (43, 3, 4.5, 'Satisfied with the purchase');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (44, 2, 3.5, 'Decent product for the price');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (44, 3, 4.0, 'Met my expectations');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (45, 2, 2.0, 'Not as expected');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (45, 3, 2.5, 'Could be improved');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (46, 2, 4.5, 'Outstanding quality!');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (46, 3, 5.0, 'Impressed with the product');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (47, 2, 3.0, 'Average product');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (47, 3, 3.5, 'Met my basic requirements');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (48, 2, 4.0, 'Good value for money');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (48, 3, 4.5, 'Satisfied with the purchase');

INSERT INTO productreview(productid, customerid, rating, review) VALUES (49, 2, 2.5, 'Below expectations');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (49, 3, 3.0, 'Could be improved');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (50, 2, 4.0, 'Good quality product');
INSERT INTO productreview(productid, customerid, rating, review) VALUES (50, 3, 4.5, 'Satisfied with the purchase');



-- INSERT INTO orders(orderdate,shippeddate,customerid,storeid,addressid,total,status) VALUES ('2020-12-01 12:12:12','2020-12-02 10:12:12',2,1,1,120,'initiated');
-- INSERT INTO orders(orderdate,shippeddate,customerid,storeid,addressid,total,status) VALUES ('2020-12-01 12:12:12','2020-12-02 10:12:12',2,1,1,480,'cancelled');



-- ORDER_DETAILS DATA
-- INSERT INTO orderdetails(orderid,productdetailsid,quantity) VALUES (1,1,1);
-- INSERT INTO orderdetails(orderid,productdetailsid,quantity) VALUES (2,2,2);


-- CARTS DATA
INSERT INTO carts(customerid) VALUES (2);
INSERT INTO carts(customerid) VALUES (3);



-- CARTS ITEMS DATA
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(1,1,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(1,3,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(1,5,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(1,11,1);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(2,9,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(2,17,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(2,19,2);


-- PAYMENTS DATA
-- INSERT INTO payments(date,mode,paymentstatus,transactionid,orderid) VALUES('2022-03-08 12:08:19','cash on delivery','paid',1,1);

-- INSERT INTO payments(date,mode,paymentstatus,transactionid,orderid) VALUES('2022-03-08 12:08:19','cash on delivery','paid',2,2);

INSERT INTO questioncategories(category) VALUES('Crop Cultivation');
INSERT INTO questioncategories(category) VALUES('Livestock Farming');
INSERT INTO questioncategories(category) VALUES('Farm Equipment and Technology');
INSERT INTO questioncategories(category) VALUES('Organic and Sustainable Farming');
INSERT INTO questioncategories(category) VALUES('Farm Business and Economics');
INSERT INTO questioncategories(category) VALUES('Farming in Different Climates and Regions');
INSERT INTO questioncategories(category) VALUES('Farm Safety and Regulations');
INSERT INTO questioncategories(category) VALUES('Farm Education and Training');

INSERT INTO questioncategories(category) VALUES('Specialty Farming');
INSERT INTO questioncategories(category) VALUES('Farm Challenges and Solutions');

-- QUESTION TABLE DATA
INSERT INTO questions(description,categoryid) VALUES(' How can I improve soil fertility in my fields?',1);
INSERT INTO questions(description,categoryid) VALUES('What are the best practices for pest and weed control in organic farming?',1);
INSERT INTO questions(description,categoryid) VALUES('How can I conserve water in my irrigation practices?',1);
INSERT INTO questions(description,categoryid) VALUES('What should I consider when selecting crop varieties for my region?',1);
INSERT INTO questions(description,categoryid)VALUES('How can I reduce post-harvest losses and improve storage methods for my crops?',1);
INSERT INTO questions(description,categoryid) VALUES('Are there government programs or subsidies available to support sustainable farming practices?',1);
INSERT INTO questions(description,categoryid) VALUES('What steps can I take to transition from conventional to organic farming?',1);
INSERT INTO questions(description,categoryid) VALUES(' How can I improve the overall profitability of my farm?',1);
INSERT INTO questions(description,categoryid) VALUES(' What are the signs of nutrient deficiencies in my crops, and how can I address them?',1);
INSERT INTO questions(description,categoryid) VALUES('What are the potential impacts of climate change on my farming practices, and how can I adapt?',1);



INSERT INTO questions(description,categoryid) VALUES(' How can I improve the health and well-being of my livestock?',2);
INSERT INTO questions(description,categoryid) VALUES('What is the best way to manage grazing and forage for my livestock?',2);
INSERT INTO questions(description,categoryid) VALUES('What are the signs of common illnesses or parasites in livestock, and how should I treat them?',2);
INSERT INTO questions(description,categoryid) VALUES(' How can I improve the breeding and genetics of my livestock?',2);
INSERT INTO questions(description,categoryid)VALUES('What are the best practices for handling and transportation of livestock?',2);
INSERT INTO questions(description,categoryid) VALUES('How can I market my livestock and their products effectively?',2);
INSERT INTO questions(description,categoryid) VALUES('What should I consider when building or renovating livestock housing and facilities?',2);
INSERT INTO questions(description,categoryid) VALUES('  What is the role of technology in modern livestock farming?',2);
INSERT INTO questions(description,categoryid) VALUES('How can I implement sustainable practices in my livestock farm?',2);
INSERT INTO questions(description,categoryid) VALUES('What financial resources and support are available to livestock farmers?',2);


INSERT INTO questions(description,categoryid) VALUES(' What are the latest advancements in farm equipment technology that can benefit my farm?',3);
INSERT INTO questions(description,categoryid) VALUES('How can I ensure that my farm machinery operates at peak efficiency?',3);
INSERT INTO questions(description,categoryid) VALUES('Are there financing options available for purchasing new farm equipment or technology?',3);
INSERT INTO questions(description,categoryid) VALUES('Can you recommend a specific brand or model of a tractor or combine harvester that suits my farms needs?',3);
INSERT INTO questions(description,categoryid)VALUES('How do I integrate data collected from farm technology into my decision-making process?',3);
INSERT INTO questions(description,categoryid) VALUES('What are the best practices for storing and securing farm equipment when not in use?',3);
INSERT INTO questions(description,categoryid) VALUES('How can I troubleshoot common issues with my farm equipment without calling a technician?',3);
INSERT INTO questions(description,categoryid) VALUES('Are there local equipment rental options available for occasional use rather than purchasing expensive machinery?',3);
INSERT INTO questions(description,categoryid) VALUES('What are the safety precautions I should take when operating farm equipment?',3);
INSERT INTO questions(description,categoryid) VALUES(' How can I make the most of technology in livestock farming, such as automated feeding systems?',3);


INSERT INTO questions(description,categoryid) VALUES(' What is organic farming, and how does it differ from conventional farming?',4);
INSERT INTO questions(description,categoryid) VALUES('How can I transition from conventional farming to organic farming?',4);
INSERT INTO questions(description,categoryid) VALUES('What are some effective organic pest control methods?',4);
INSERT INTO questions(description,categoryid) VALUES('What practices can help me improve soil health in organic farming?',4);
INSERT INTO questions(description,categoryid)VALUES('How can I maintain weed control without synthetic herbicides in organic farming?',4);
INSERT INTO questions(description,categoryid) VALUES('What are the benefits of sustainable farming practices?',4);
INSERT INTO questions(description,categoryid) VALUES('How can I reduce water usage in my farming operation while maintaining crop productivity?',4);
INSERT INTO questions(description,categoryid) VALUES('Are there organic alternatives for fertilizing my crops?',4);
INSERT INTO questions(description,categoryid) VALUES('What are some tips for managing livestock sustainably?',4);
INSERT INTO questions(description,categoryid) VALUES(' How can I market my organic and sustainably grown products effectively?',4);


INSERT INTO questions(description,categoryid) VALUES('How can I create a budget for my farm that accounts for all expenses and income?',5);
INSERT INTO questions(description,categoryid) VALUES('What are some key financial ratios that I should monitor to assess the financial health of my farm?',5);
INSERT INTO questions(description,categoryid) VALUES('How do I determine the optimal scale and scope of my farm operation?',5);
INSERT INTO questions(description,categoryid) VALUES('What marketing strategies can I use to sell my farm products effectively?',5);
INSERT INTO questions(description,categoryid)VALUES('How can I negotiate fair contracts and pricing agreements with buyers and suppliers?',5);
INSERT INTO questions(description,categoryid) VALUES('What strategies can I employ to manage cash flow on my farm and ensure I have funds when needed?',5);
INSERT INTO questions(description,categoryid) VALUES('What are the potential tax implications of different farm business structures (e.g., sole proprietorship, LLC, partnership)?',5);
INSERT INTO questions(description,categoryid) VALUES('How can I diversify my farm income to reduce financial risk?',5);
INSERT INTO questions(description,categoryid) VALUES('What are the economic considerations when transitioning to organic or sustainable ',5);
INSERT INTO questions(description,categoryid) VALUES('Where can I find resources and support for farm business management and financial planning?',5);


INSERT INTO questions(description,categoryid) VALUES(' How can I determine the best crops or livestock to raise in my specific climate and region?',6);
INSERT INTO questions(description,categoryid) VALUES('What are the key challenges and solutions for managing water resources in regions with irregular rainfall patterns?',6);
INSERT INTO questions(description,categoryid) VALUES('How can I protect my crops from frost in regions with cold winters?',6);
INSERT INTO questions(description,categoryid) VALUES('What are effective strategies for managing soil erosion in hilly or mountainous regions?',6);
INSERT INTO questions(description,categoryid)VALUES('How do I adapt my planting and harvesting schedules in regions with distinct wet and dry seasons?',6);
INSERT INTO questions(description,categoryid) VALUES('What should I consider when selecting a greenhouse or high tunnel for extending the growing season in a cold climate?',6);
INSERT INTO questions(description,categoryid) VALUES('How can I manage salt-affected soils in coastal farming regions?',6);
INSERT INTO questions(description,categoryid) VALUES('Are there specific pest and disease challenges that farmers face in humid climates, and how can they be managed?',6);
INSERT INTO questions(description,categoryid) VALUES('What are the benefits of crop rotation and diversified farming practices in regions with unpredictable climate patterns?',6);
INSERT INTO questions(description,categoryid) VALUES(' How can I connect with other farmers in my region to share knowledge and experiences related to farming in our specific climate?',6);




INSERT INTO questions(description,categoryid) VALUES('What are the key safety measures I should implement on my farm to protect myself, my family, and my workers?',7);
INSERT INTO questions(description,categoryid) VALUES('What safety regulations and guidelines apply to my farm, and how can I ensure compliance?',7);
INSERT INTO questions(description,categoryid) VALUES('How can I prevent accidents and injuries related to farm equipment and machinery?',7);
INSERT INTO questions(description,categoryid) VALUES('What measures should I take to ensure the safety of children on my farm?',7);
INSERT INTO questions(description,categoryid)VALUES('How can I mitigate the risk of fire hazards on my farm, especially in areas with dry conditions?',7);
INSERT INTO questions(description,categoryid) VALUES('What biosecurity measures are important for preventing disease outbreaks among livestock?',7);
INSERT INTO questions(description,categoryid) VALUES('How can I ensure food safety for farm products, especially if Im selling directly to consumers?',7);
INSERT INTO questions(description,categoryid) VALUES('Are there specific safety considerations for handling and storing pesticides and chemicals on the farm?',7);
INSERT INTO questions(description,categoryid) VALUES('What are the best practices for handling and disposing of hazardous farm waste materials?',7);
INSERT INTO questions(description,categoryid) VALUES('Where can I access resources and training programs related to farm safety and regulations in my area?',7);




INSERT INTO questions(description,categoryid) VALUES('What are the best resources for learning about the latest advancements in farming technology and techniques?',8);
INSERT INTO questions(description,categoryid) VALUES('Are there specific courses or programs that can help me transition from conventional to organic farming?',8);
INSERT INTO questions(description,categoryid) VALUES(' How can I access training on sustainable farming practices, such as regenerative agriculture or permaculture?',8);
INSERT INTO questions(description,categoryid) VALUES('What are the financial benefits of attending agricultural training programs, and how can I find funding for them?',8);
INSERT INTO questions(description,categoryid)VALUES('Are there mentorship programs available for new farmers to learn from experienced farmers in my area?',8);
INSERT INTO questions(description,categoryid) VALUES('What are some essential topics I should cover in a farm business management course?',8);
INSERT INTO questions(description,categoryid) VALUES(' How can I find opportunities for hands-on training and apprenticeships on farms?',8);
INSERT INTO questions(description,categoryid) VALUES('What are the benefits of joining a farming cooperative or association, and how can I find one in my area?',8);
INSERT INTO questions(description,categoryid) VALUES('Are there government programs or incentives to encourage ongoing education and training for farmers?',8);
INSERT INTO questions(description,categoryid) VALUES('How can I balance the demands of running my farm with the need for continuous learning and training?',8);



INSERT INTO questions(description,categoryid) VALUES(' What is specialty farming, and how does it differ from traditional farming?',9);
INSERT INTO questions(description,categoryid) VALUES(' How can I identify profitable specialty crops or niche markets for my farm?',9);
INSERT INTO questions(description,categoryid) VALUES(' What are the key considerations for successfully growing specialty crops like gourmet mushrooms or exotic herbs?',9);
INSERT INTO questions(description,categoryid) VALUES('Are there certification processes or quality standards for specialty or organic products, and how can I meet them?',9);
INSERT INTO questions(description,categoryid)VALUES(' How can I market my specialty farm products effectively to reach the right customer base?',9);
INSERT INTO questions(description,categoryid) VALUES(' What are the challenges and benefits of raising specialty livestock breeds, such as heritage poultry or rare breeds?',9);
INSERT INTO questions(description,categoryid) VALUES(' What resources and support are available for farmers interested in specialty farming, such as grants or training programs?',9);
INSERT INTO questions(description,categoryid) VALUES(' How can I diversify my farm income through specialty products while managing the risks associated with niche markets?',9);
INSERT INTO questions(description,categoryid) VALUES('What are the environmental and sustainability considerations for specialty farming practices?',9);
INSERT INTO questions(description,categoryid) VALUES('How can I stay updated on the latest trends and opportunities in the specialty farming sector?',9);



INSERT INTO questions(description,categoryid) VALUES('How can I improve soil fertility and structure on my farm over time?',10);
INSERT INTO questions(description,categoryid) VALUES(' What are effective strategies for reducing the environmental impact of my farm, especially in terms of water and nutrient runoff?',10);
INSERT INTO questions(description,categoryid) VALUES(' How can I address labor shortages on my farm, especially during peak seasons?',10);
INSERT INTO questions(description,categoryid) VALUES('What measures can I take to enhance the welfare and health of my livestock while also improving production efficiency?',10);
INSERT INTO questions(description,categoryid)VALUES(' How can I reduce energy consumption and make my farm more energy-efficient?',10);
INSERT INTO questions(description,categoryid) VALUES('What financial management strategies can help me maintain a stable income in the face of market volatility?',10);
INSERT INTO questions(description,categoryid) VALUES(' How can I adapt my farming practices to changing weather patterns and climate conditions?',10);
INSERT INTO questions(description,categoryid) VALUES(' What are the best practices for marketing and selling my farm products directly to consumers or through local markets?',10);
INSERT INTO questions(description,categoryid) VALUES('How can I manage the challenges of transitioning from conventional to organic farming practices?',10);
INSERT INTO questions(description,categoryid) VALUES(' What steps should I take to ensure the long-term sustainability and profitability of my farm?',10);

-- CUSTOMERQUESTIONS TABLE DATA
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,1,'2023-10-01');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,2,'2023-10-01');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,3,'2023-10-01');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,4,'2023-10-01');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,5,'2023-10-02');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,6,'2023-10-02');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (19,7,'2023-10-02');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (20,8,'2023-10-03');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (21,9,'2023-10-03');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (22,10,'2023-10-03');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (23,11,'2023-10-03');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (24,12,'2023-10-03');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (25,13,'2023-10-03');



INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,14,'2023-10-03');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,15,'2023-10-04');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,16,'2023-10-04');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,17,'2023-10-04');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,18,'2023-10-05');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,19,'2023-10-05');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,20,'2023-10-06');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (19,21,'2023-10-07');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (20,22,'2023-10-08');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (21,13,'2023-10-09');




INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (22,23,'2023-10-010');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (23,24,'2023-10-010');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (24,25,'2023-10-11');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (25,26,'2023-10-12');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,27,'2023-10-12');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,28,'2023-10-13');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,29,'2023-10-13');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,30,'2023-10-13');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,31,'2023-10-14');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,32,'2023-10-14');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (19,33,'2023-10-14');



INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (20,34,'2023-10-15');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (21,35,'2023-10-16');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (22,36,'2023-10-17');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (23,37,'2023-10-17');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (24,38,'2023-10-17');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (25,39,'2023-10-17');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,40,'2023-10-18');



INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,41,'2023-10-18');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,42,'2023-10-19');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,43,'2023-10-19');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,44,'2023-10-20');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,45,'2023-10-20');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,46,'2023-10-20');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (19,47,'2023-10-20');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (20,48,'2023-10-21');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (21,49,'2023-10-21');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (22,50,'2023-10-21');



INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (23,51,'2023-10-21');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (24,52,'2023-10-22');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (25,53,'2023-10-22');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,54,'2023-10-23');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,55,'2023-10-23');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,56,'2023-10-23');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,57,'2023-10-23');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,58,'2023-10-23');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,59,'2023-10-24');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (19,60,'2023-10-24');


INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (20,61,'2023-10-24');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (21,62,'2023-10-24');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (22,63,'2023-10-24');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (23,64,'2023-10-24');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (24,65,'2023-10-25');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (25,66,'2023-10-25');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,67,'2023-10-25');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,68,'2023-10-25');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,69,'2023-10-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,70,'2023-10-26');



INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,71,'2023-10-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,72,'2023-10-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (19,73,'2023-10-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (20,74,'2023-10-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (21,75,'2023-10-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (22,76,'2023-10-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (23,77,'2023-10-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (24,78,'2023-10-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (25,79,'2023-10-27');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,80,'2023-10-27');


INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,81,'2023-10-27');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,82,'2023-10-27');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,83,'2023-10-27');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,84,'2023-10-28');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,85,'2023-10-28');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (19,86,'2023-10-29');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (20,87,'2023-10-29');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (21,88,'2023-10-29');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (22,89,'2023-10-29');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (23,90,'2023-10-29');


INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (24,91,'2023-10-29');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (25,92,'2023-10-29');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,93,'2023-10-30');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,94,'2023-10-30');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,95,'2023-10-30');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,96,'2023-10-30');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,97,'2023-10-31');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,98,'2023-10-31');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (19,99,'2023-10-31');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (20,100,'2023-10-31');

-- SME TABLE DATA
INSERT INTO subjectmatterexperts(expertise,userid) VALUES('crop related information',8);
INSERT INTO subjectmatterexperts(expertise,userid) VALUES('soil related information',9);



-- ANSWERS TABLE DATA

INSERT INTO answers(description,questionid) VALUES('You can enhance soil fertility through practices like adding organic matter (compost or manure), conducting soil tests to determine nutrient needs, and practicing crop rotation.',1);
INSERT INTO answers(description,questionid) VALUES('In organic farming, you can use methods like companion planting, beneficial insects, and organic pesticides to control pests and weeds without synthetic chemicals.',2);
INSERT INTO answers(description,questionid)VALUES(' Implement water-efficient irrigation methods such as drip irrigation or sprinkler systems, and schedule irrigation based on the specific water needs of your crops.',3);
INSERT INTO answers(description,questionid) VALUES('Choose crop varieties that are well-suited to your local climate, soil type, and disease resistance to optimize yield and reduce risks.',4);
INSERT INTO answers(description,questionid) VALUES('You can minimize post-harvest losses by using proper storage facilities, maintaining the right temperature and humidity levels, and adopting good handling practices.',5);
INSERT INTO answers(description,questionid) VALUES(' Many governments offer programs, grants, and subsidies to encourage sustainable and environmentally friendly farming practices. Its worth exploring these opportunities.',6);
INSERT INTO answers(description,questionid) VALUES(' Transitioning to organic farming may involve gradually reducing chemical inputs, adopting organic certification standards, and learning about organic pest and weed management techniques.',7);
INSERT INTO answers(description,questionid) VALUES(' Strategies to improve profitability may include diversifying crops, exploring niche markets, reducing production costs, and optimizing resource use.',8);
INSERT INTO answers(description,questionid) VALUES('Signs of nutrient deficiencies can include yellowing leaves, stunted growth, and poor fruiting. Address them by applying the appropriate nutrients through fertilization.',9);
INSERT INTO answers(description,questionid) VALUES('Climate change can affect growing seasons and precipitation patterns. To adapt, consider adjusting planting dates, selecting climate-resilient crops, and implementing efficient water management.',10);


INSERT INTO answers(description,questionid) VALUES('Improving livestock health involves providing proper nutrition, clean water, shelter, and regular veterinary care. Its also important to manage stress factors and ensure good sanitation practices.',11);
INSERT INTO answers(description,questionid) VALUES('Effective grazing management includes rotational grazing, maintaining pasture health, and ensuring access to fresh forage to optimize your livestocks nutrition.',12);
INSERT INTO answers(description,questionid)VALUES('Look for signs like changes in behavior, weight loss, or abnormal physical symptoms. Consult with a veterinarian for a proper diagnosis and treatment plan.',13);
INSERT INTO answers(description,questionid) VALUES('To improve livestock genetics, consider selective breeding, artificial insemination, or using high-quality breeding stock to enhance desirable traits in your herd or flock.',14);
INSERT INTO answers(description,questionid) VALUES('Proper handling and transportation techniques help reduce stress and ensure the safety of both animals and handlers. Learn about low-stress handling methods and comply with transportation regulations.',15);
INSERT INTO answers(description,questionid) VALUES('Effective marketing strategies may include identifying target markets, establishing relationships with buyers, and utilizing online platforms or local markets to sell your livestock and products.',16);
INSERT INTO answers(description,questionid) VALUES('Consider factors like animal comfort, ventilation, waste management, and biosecurity when designing or updating your livestock facilities.',17);
INSERT INTO answers(description,questionid) VALUES('Technology can improve livestock farming through tools like automated feeding systems, health monitoring devices, and data analytics to enhance productivity and animal welfare.',18);
INSERT INTO answers(description,questionid) VALUES('Sustainable livestock farming practices may involve conserving water, reducing waste, using renewable energy sources, and adopting rotational grazing to preserve soil health.',19);
INSERT INTO answers(description,questionid) VALUES('Explore government grants, subsidies, and agricultural extension services that may offer financial support and guidance to improve your livestock farming operation.',20);


INSERT INTO answers(description,questionid) VALUES('Stay updated on innovations like autonomous tractors, precision planting systems, and remote monitoring technology to see how they can improve your farms efficiency.',21);
INSERT INTO answers(description,questionid) VALUES('Regular maintenance, proper calibration, and following manufacturer guidelines for equipment use are essential to keep your farm machinery in top working condition.',22);
INSERT INTO answers(description,questionid)VALUES('Explore financing options, including loans, leasing, or government programs, that can help you acquire the necessary equipment and technology for your farm.',23);
INSERT INTO answers(description,questionid) VALUES('Seek advice from equipment dealers or agricultural experts who can assess your farms requirements and recommend suitable machinery.',24);
INSERT INTO answers(description,questionid) VALUES('You can use farm management software to collect and analyze data from sensors and machinery, enabling you to make informed decisions about planting, irrigation, and more.',25);
INSERT INTO answers(description,questionid) VALUES(' Proper storage includes cleaning, covering, and securing machinery to protect it from the elements and potential theft.',26);
INSERT INTO answers(description,questionid) VALUES(' Learn about basic troubleshooting techniques for common machinery problems, such as engine issues or hydraulic system malfunctions, to minimize downtime.',27);
INSERT INTO answers(description,questionid) VALUES('Look for equipment rental services in your area, which can be cost-effective for occasional or specialized tasks.',28);
INSERT INTO answers(description,questionid) VALUES('Ensure all operators receive proper training and follow safety protocols, including wearing appropriate protective gear and conducting pre-operation checks.',29);
INSERT INTO answers(description,questionid) VALUES('Explore the benefits of technology like automated feeders, which can improve feed efficiency and reduce labor while ensuring proper nutrition for your livestock.',30);


INSERT INTO answers(description,questionid) VALUES('Organic farming avoids synthetic chemicals and genetically modified organisms (GMOs) and focuses on soil health, crop rotation, and organic fertilizers to promote sustainability.',31);
INSERT INTO answers(description,questionid) VALUES('The transition typically involves ceasing the use of synthetic pesticides and fertilizers, adopting organic practices, and undergoing a certification process. Consult with organic farming experts for guidance.',32);
INSERT INTO answers(description,questionid)VALUES('Organic pest control methods include beneficial insects, companion planting, neem oil, and organic pesticides that are approved for organic farming.',33);
INSERT INTO answers(description,questionid) VALUES('Practices such as cover cropping, composting, reduced tillage, and crop rotation can enhance soil health and fertility in organic farming.',34);
INSERT INTO answers(description,questionid) VALUES(' Strategies include mulching, mechanical cultivation, flame weeding, and using cover crops that suppress weeds.',35);
INSERT INTO answers(description,questionid) VALUES('  Sustainable farming practices promote long-term environmental stewardship, conserve natural resources, reduce chemical inputs, and improve soil and water quality.',36);
INSERT INTO answers(description,questionid) VALUES(' Implement water-efficient irrigation methods, such as drip or pivot irrigation, and use soil moisture monitoring systems to optimize water use.',37);
INSERT INTO answers(description,questionid) VALUES(' Organic fertilizers like compost, manure, bone meal, and fish emulsion can provide essential nutrients to crops without synthetic chemicals.',38);
INSERT INTO answers(description,questionid) VALUES('Sustainable livestock management involves rotational grazing, proper animal welfare practices, and using organic feed and forage whenever possible.',39);
INSERT INTO answers(description,questionid) VALUES('Utilize organic certification labels, participate in local farmers markets, and establish partnerships with restaurants and retailers that support sustainable and organic products.',40);


INSERT INTO answers(description,questionid) VALUES('Creating a comprehensive budget involves listing all expenses (such as seeds, labor, and equipment maintenance) and estimating income from crop sales, livestock, and other sources.',41);
INSERT INTO answers(description,questionid) VALUES('Key financial ratios include the debt-to-equity ratio, the current ratio, and the return on assets. These ratios can provide insights into your farms financial stability and efficiency.',42);
INSERT INTO answers(description,questionid)VALUES(' Assess your resources, market demand, and production capabilities to determine the right size and scope for your farm. Consider factors like available land and labor, as well as your financial goals.',43);
INSERT INTO answers(description,questionid) VALUES(' Effective marketing strategies may include developing a strong online presence, participating in farmers markets, establishing relationships with restaurants and retailers, and utilizing social media.',44);
INSERT INTO answers(description,questionid) VALUES('  Negotiating fair contracts involves understanding market prices, product quality standards, and the terms and conditions of agreements. Seek legal advice if necessary.',45);
INSERT INTO answers(description,questionid) VALUES(' Strategies include maintaining a cash reserve, securing lines of credit, and aligning expenses with revenue to avoid cash flow shortages.',46);
INSERT INTO answers(description,questionid) VALUES(' Consult with a tax advisor to understand the tax advantages and disadvantages of different business structures and choose the one that suits your farms needs.',47);
INSERT INTO answers(description,questionid) VALUES('Diversification can include adding new crops or livestock, offering agritourism activities, or producing value-added products like jams or cheeses.',48);
INSERT INTO answers(description,questionid) VALUES('Transitioning may involve initial investment in soil health and organic certification. Assess the long-term economic benefits and consider grants or subsidies available for sustainable practices.',49);
INSERT INTO answers(description,questionid) VALUES('Look for agricultural extension services, farm management courses, and government agencies that offer guidance and resources to help farmers manage their farm businesses effectively.',50);


INSERT INTO answers(description,questionid) VALUES(' Consider factors like temperature, precipitation, soil type, and local market demand when selecting crops or livestock breeds that are well-suited to your region.',51);
INSERT INTO answers(description,questionid) VALUES('Solutions may include rainwater harvesting, efficient irrigation systems, and drought-resistant crop varieties to optimize water use during dry spells.',52);
INSERT INTO answers(description,questionid)VALUES(' Frost protection methods include using frost blankets, wind machines, and selecting frost-tolerant crop varieties.',53);
INSERT INTO answers(description,questionid) VALUES('Practices like contour farming, terracing, and cover cropping can help prevent soil erosion on slopes.',54);
INSERT INTO answers(description,questionid) VALUES(' Timing your planting and harvesting to align with the rainy season can optimize crop growth and yield.',55);
INSERT INTO answers(description,questionid) VALUES(' Factors to consider include greenhouse design, heating options, and insulation to create a suitable microclimate for your crops.',56);
INSERT INTO answers(description,questionid) VALUES(' Soil amendments like gypsum, proper drainage systems, and salt-tolerant crop varieties can help address salt-affected soils.',57);
INSERT INTO answers(description,questionid) VALUES(' Humid regions may have issues with fungal diseases and insect pests. Integrated pest management (IPM) practices, proper sanitation, and disease-resistant crop varieties can help manage these challenges.',58);
INSERT INTO answers(description,questionid) VALUES(' Crop rotation and diversification can help spread risk and reduce the impact of adverse weather conditions on the farm.',59);
INSERT INTO answers(description,questionid) VALUES(' Local farmer networks, agricultural cooperatives, and extension services can provide opportunities to connect with other farmers and share insights about regional farming challenges and solutions.',60);




INSERT INTO answers(description,questionid) VALUES(' Key safety measures include providing training, using protective equipment, maintaining machinery, and establishing safety protocols for tasks like handling chemicals or working with livestock.',61);
INSERT INTO answers(description,questionid) VALUES('Regulations may vary by location, but they often cover areas like worker safety, chemical handling, and food safety. Consult with local agricultural agencies or authorities to understand and adhere to relevant regulations.',62);
INSERT INTO answers(description,questionid)VALUES(' Implement safety practices like equipment inspections, proper machine guarding, and safe operating procedures. Provide training to all personnel operating machinery.',63);
INSERT INTO answers(description,questionid) VALUES(' Establish child safety guidelines, including restricted access to hazardous areas, supervision, and age-appropriate tasks for children.',64);
INSERT INTO answers(description,questionid) VALUES('Practices like maintaining firebreaks, proper storage of flammable materials, and having firefighting equipment on hand can help reduce fire risks.',65);
INSERT INTO answers(description,questionid) VALUES('  Biosecurity measures may include quarantine for new animals, proper sanitation, and limiting visitor access to prevent the spread of diseases.',66);
INSERT INTO answers(description,questionid) VALUES('  Implement food safety practices such as proper handling, storage, and labeling of farm products, and consider obtaining any necessary food safety certifications.',67);
INSERT INTO answers(description,questionid) VALUES('  Yes, safety precautions include proper storage, labeling, and handling procedures for chemicals. Follow the manufacturers instructions and local regulations.',68);
INSERT INTO answers(description,questionid) VALUES('Properly store and dispose of hazardous materials like pesticides, chemicals, and used oil according to local regulations and guidelines.',69);
INSERT INTO answers(description,questionid) VALUES('Look for local agricultural extension services, farm safety organizations, and training programs that offer guidance and support for farm safety and regulatory compliance.',70);




INSERT INTO answers(description,questionid) VALUES('Look for agricultural extension programs, research institutions, and industry publications that offer information on cutting-edge farming practices.',71);
INSERT INTO answers(description,questionid) VALUES(' Many agricultural colleges and organizations offer courses and programs tailored to farmers interested in transitioning to organic farming.',72);
INSERT INTO answers(description,questionid)VALUES('Explore local workshops, online courses, and resources provided by sustainable agriculture organizations to learn about these practices.',73);
INSERT INTO answers(description,questionid) VALUES(' Some training programs may offer financial incentives or scholarships. Additionally, check with agricultural agencies and organizations for funding opportunities.',74);
INSERT INTO answers(description,questionid) VALUES(' Look for local mentorship programs or agricultural associations that facilitate connections between experienced and aspiring farmers.',75);
INSERT INTO answers(description,questionid) VALUES('Farm business management courses typically cover topics such as budgeting, marketing, record-keeping, and risk management.',76);
INSERT INTO answers(description,questionid) VALUES(' Reach out to local farms, agricultural colleges, and organizations that offer apprenticeship programs to gain practical experience.',77);
INSERT INTO answers(description,questionid) VALUES(' Farming cooperatives and associations can provide networking, support, and educational opportunities. Search online or ask fellow farmers for recommendations.',78);
INSERT INTO answers(description,questionid) VALUES(' Some government programs may provide grants or tax incentives to support farmers education and training efforts.',79);
INSERT INTO answers(description,questionid) VALUES('Time management and prioritization are key. Allocate dedicated time for learning, and consider online or flexible training options to fit your schedule.',80);



INSERT INTO answers(description,questionid) VALUES(' Specialty farming focuses on the production of unique or niche crops, products, or livestock that cater to specific markets or consumer preferences, often deviating from traditional mainstream agriculture.',81);
INSERT INTO answers(description,questionid) VALUES(' Research local market demands, consumer trends, and potential niche products to identify profitable opportunities for your farm.',82);
INSERT INTO answers(description,questionid)VALUES('Specialty crop success involves understanding specific growing conditions, disease management, and finding the right market outlets for your products.',83);
INSERT INTO answers(description,questionid) VALUES(' Yes, there are often certification processes and quality standards for specialty and organic products. Consult with certifying bodies and follow their guidelines for compliance.',84);
INSERT INTO answers(description,questionid) VALUES(' Effective marketing strategies include branding, participating in farmers markets, building relationships with local chefs and restaurants, and utilizing social media and online platforms.',85);
INSERT INTO answers(description,questionid) VALUES(' Challenges may include smaller market sizes, while benefits may include higher prices per unit and the preservation of rare or endangered breeds.',86);
INSERT INTO answers(description,questionid) VALUES('  Explore agricultural extension services, specialty crop grants, and local agricultural organizations that offer resources and support for specialty farmers.',87);
INSERT INTO answers(description,questionid) VALUES(' Diversification involves careful market research, risk assessment, and a well-thought-out business plan that includes both mainstream and specialty products.',88);
INSERT INTO answers(description,questionid) VALUES('Specialty farming practices should align with sustainable and environmentally responsible methods, which may include organic or regenerative farming techniques.',89);
INSERT INTO answers(description,questionid) VALUES(' Attend specialty crop conferences, subscribe to niche farming publications, and network with other specialty farmers to stay informed about trends and opportunities.',90);



INSERT INTO answers(description,questionid) VALUES(' Consider implementing practices like crop rotation, cover cropping, and organic matter additions to enhance soil health and fertility.',91);
INSERT INTO answers(description,questionid) VALUES('Implement best management practices (BMPs) like controlled drainage, nutrient management plans, and riparian buffer zones to reduce runoff and protect water quality.',92);
INSERT INTO answers(description,questionid)VALUES(' Explore labor-saving technologies such as automated machinery and consider hiring seasonal or temporary workers to meet labor demands.',93);
INSERT INTO answers(description,questionid) VALUES(' Focus on proper nutrition, housing, and disease prevention through vaccination and biosecurity measures to promote animal welfare and productivity.',94);
INSERT INTO answers(description,questionid) VALUES(' Implement energy-efficient practices such as upgrading equipment, using renewable energy sources, and optimizing building insulation.',95);
INSERT INTO answers(description,questionid) VALUES('Consider diversifying your income sources, exploring contract farming agreements, and using risk management tools like futures contracts to hedge against price fluctuations.',96);
INSERT INTO answers(description,questionid) VALUES('  Develop resilient farming practices like drought-tolerant crops, efficient irrigation, and improved drainage systems to adapt to climate variability.',97);
INSERT INTO answers(description,questionid) VALUES(' Build a strong online presence, participate in farmers  markets, offer farm-to-table experiences, and engage with community-supported agriculture (CSA) programs.',98);
INSERT INTO answers(description,questionid) VALUES('Gradually transition by implementing organic practices, improving soil health, and seeking organic certification when ready.',99);
INSERT INTO answers(description,questionid) VALUES('Create a comprehensive farm business plan, monitor key performance indicators, and continually seek opportunities for improvement and innovation.',100);

-- SME ANSWERS
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (1,'2023-04-05 12:08:06',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (1,'2023-06-05 12:20:19',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (2,'2023-07-10 12:23:08',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (2,'2023-08-25 12:34:20',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (3,'2023-09-15 12:40:30',2);
