-- Active: 1678359546568@@127.0.0.1@3306@ekrushi

INSERT INTO roles(name) VALUES ('Shop Owner');
INSERT INTO roles(name) VALUES ('Customer');
INSERT INTO roles(name) VALUES ('Supplier');
INSERT INTO roles(name) VALUES ('Shipper');
INSERT INTO roles(name) VALUES ('SubjectMatterExpert');

INSERT INTO userroles(userid,roleid) VALUES (1,1);
INSERT INTO userroles(userid,roleid) VALUES (4,1);
INSERT INTO userroles(userid,roleid) VALUES (28,1);
INSERT INTO userroles(userid,roleid) VALUES (29,1);
INSERT INTO userroles(userid,roleid) VALUES (30,1);

INSERT INTO userroles(userid,roleid) VALUES (2,2);
INSERT INTO userroles(userid,roleid) VALUES (3,2);
INSERT INTO userroles(userid,roleid) VALUES (15,2);
INSERT INTO userroles(userid,roleid) VALUES (16,2);
INSERT INTO userroles(userid,roleid) VALUES (17,2);
INSERT INTO userroles(userid,roleid) VALUES (18,2);
INSERT INTO userroles(userid,roleid) VALUES (19,2);
INSERT INTO userroles(userid,roleid) VALUES (20,2);
INSERT INTO userroles(userid,roleid) VALUES (21,2);
INSERT INTO userroles(userid,roleid) VALUES (22,2);
INSERT INTO userroles(userid,roleid) VALUES (23,2);
INSERT INTO userroles(userid,roleid) VALUES (24,2);
INSERT INTO userroles(userid,roleid) VALUES (25,2);
INSERT INTO userroles(userid,roleid) VALUES (26,2);
INSERT INTO userroles(userid,roleid) VALUES (27,2);

INSERT INTO userroles(userid,roleid) VALUES (11,3);
INSERT INTO userroles(userid,roleid) VALUES (12,3);

INSERT INTO userroles(userid,roleid) VALUES (31,4);
INSERT INTO userroles(userid,roleid) VALUES (32,4);
INSERT INTO userroles(userid,roleid) VALUES (33,4);
INSERT INTO userroles(userid,roleid) VALUES (34,4);
INSERT INTO userroles(userid,roleid) VALUES (35,4);



INSERT INTO userroles(userid,roleid) VALUES (8,5);
INSERT INTO userroles(userid,roleid) VALUES (9,5);
INSERT INTO userroles(userid,roleid) VALUES (36,5);
INSERT INTO userroles(userid,roleid) VALUES (37,5);
INSERT INTO userroles(userid,roleid) VALUES (38,5);
INSERT INTO userroles(userid,roleid) VALUES (39,5);
INSERT INTO userroles(userid,roleid) VALUES (40,5);




INSERT INTO stores(name,userid,addressid) VALUES  ("Manchar Store",1,1);
INSERT INTO stores(name,userid,addressid) VALUES  ("Rajgurunagar Store ",4,4);
INSERT INTO stores(name,userid,addressid) VALUES  ("Narayangaon Store ",28,20);
INSERT INTO stores(name,userid,addressid) VALUES  ("Karegaon Store ",29,21);
INSERT INTO stores(name,userid,addressid) VALUES  ("Junner Store",30,22);

INSERT INTO suppliers(corporateid,userid) VALUES(8,11);
INSERT INTO suppliers(corporateid,userid) VALUES(9,12);


INSERT INTO shippers(userid,addressid) VALUES(31,23);
INSERT INTO shippers(userid,addressid) VALUES(32,24);
INSERT INTO shippers(userid,addressid) VALUES(33,25);
INSERT INTO shippers(userid,addressid) VALUES(34,26);
INSERT INTO shippers(userid,addressid) VALUES(35,27);


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
INSERT INTO products(title,description,image,categoryid) VALUES(' Bajra Seeds',' Its annual seed bajra when compared to fodder bajra will re-grow after each harvest (multi-cut),
                                                                     fast-growing cover crop with an extensive root system and heat-loving summer annual grass. It can grow 7-11 feet tall with long depending upon soil conditions, low water requirement, drought tolerance, slender leaves and no leaf blades. The leaves are similar to corn/maize but are shorter and sometimes wider. Fodder quality will be high due to low fibre content if cut frequently. Seed rate is 9-10 kg/acre, good seed germination like above 95 %; spacing is 0.5x1 feet for single seeds sow. Irrigation is 7–9 days depending upon soil conditions and suitable for anywhere climatic conditions in India. Give irrigation immediately after sowing and life/second irrigation on 3rd day from date of sowing then irrigate once in 10 days. Conduct on first harvest 60th days after sowing, then subsequent harvest 30-35 days once. It’s having 8.93-11.5 % of Crude Protein and Fat contains 4.81 %. Green fodder yield is 27-30 t/acre/yr. Used primarily for pastures, grazing, green chop, silage and hay. Good green fodder to Cow, Buffalo, Goat and Sheep. Improving milk yield and body weight also.','/assets/bajra-seeds.webp',1);
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
INSERT INTO products(title,description,image,categoryid) VALUES('KAPILA HI PRO','A feed that has just right amount of protein (24%) and fat (4%),
                                                                     Manufactured under International Organisation Standards. It is made of completely natural products that will help your cattle to give milk to its full potential and remain healthy for longer period of time.','/assets/hi-pro.jpg',5);


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
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(23,1400,1000,'50kg',2);
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
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(33,325,1000,'250gm',1);
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


INSERT INTO orders VALUES 
(2,'2023-07-01 16:57:20','  2023-07-05 16:57:20',3,3,4,14760,'delivered'),
(3,'2023-07-02 16:58:34','  2023-07-06 16:58:34',3,3,4,2620,'delivered'),
(4,'2023-07-03 16:59:03','  2023-07-07 16:59:03',3,3,4,1700,'delivered'),
(5,'2023-07-04 16:59:51','  2023-07-08 16:59:51',3,3,4,10620,'delivered'),
(6,'2023-07-05 17:02:19','  2023-07-09 17:02:19',2,2,4,18450,'delivered'),
(7,'2023-07-06 17:02:45','  2023-07-10 17:02:45',2,2,4,470,'delivered'),
(8,'2023-07-07 17:03:28','  2023-07-11 17:03:28',2,2,4,740,'delivered'),
(9,'2023-07-08 17:04:01','  2023-07-12 17:04:01',2,2,4,1700,'delivered'),
(10,'2023-07-09 17:04:50','  2023-07-13 17:04:50',2,2,4,1500,'delivered'),
(11,'2023-07-10 17:05:54','  2023-07-14 17:05:54',15,7,4,250,'delivered'),
(12,'2023-07-11 17:06:23','  2023-07-15 17:06:23',15,7,4,12400,'delivered'),
(13,'2023-07-12 17:06:49','  2023-07-16 17:06:49',15,7,4,3470,'delivered'),
(14,'2023-07-13 17:07:20','  2023-07-17 17:07:20',15,7,4,1550,'delivered'),
(15,'2023-07-14 17:07:41','  2023-07-18 17:07:41',15,7,4,600,'delivered'),
(16,'2023-10-01 17:08:34','  2023-10-02 17:08:34',16,8,1,5000,'delivered'),
(17,'2023-10-02 17:09:23','  2023-10-03 17:09:23',16,8,1,4000,'delivered'),
(18,'2023-10-03 17:09:53','  2023-10-04 17:09:53',16,8,1,4560,'delivered'),
(19,'2023-10-04 17:10:07','  2023-10-05 17:10:07',16,8,1,250,'delivered'),
(20,'2023-10-05 17:10:34','  2023-10-06 17:10:34',16,8,1,1500,'delivered'),
(21,'2023-10-06 17:11:41','  2023-10-07 17:11:41',17,9,1,5250,'delivered'),
(22,'2023-10-07 17:12:15','  2023-10-08 17:12:15',17,9,1,6350,'delivered'),
(23,'2023-10-08 17:12:54','  2023-10-09 17:12:54',17,9,1,5500,'delivered'),
(24,'2023-10-09 17:13:24','  2023-10-10 17:13:24',17,9,1,6000,'delivered'),
(25,'2023-10-10 17:14:04','  2023-10-11 17:14:04',17,9,1,1200,'delivered'),
(26,'2023-10-11 17:16:12','  2023-10-12 17:16:12',18,10,1,16950,'delivered'),
(27,'2023-10-12 17:16:37','  2023-10-13 17:16:37',18,10,1,750,'delivered'),
(28,'2023-10-13 17:17:01','  2023-10-14 17:17:01',18,10,1,1200,'delivered'),
(29,'2023-10-14 17:17:29','  2023-10-15 17:17:29',18,10,1,1600,'delivered'),
(30,'2023-10-15 17:18:01','  2023-11-16 17:18:01',18,10,1,960,'delivered'),
(31,'2023-07-30 17:18:52','  2023-08-02 17:18:52',19,11,2,8760,'delivered'),
(32,'2023-08-01 17:19:32','  2023-08-03 17:19:32',19,11,2,12000,'delivered'),
(33,'2023-08-02 17:20:28','  2023-08-04 17:20:28',19,11,2,720,'delivered'),
(34,'2023-08-03 17:21:13','  2023-08-05 17:21:13',20,12,2,19000,'delivered'),
(35,'2023-08-04 17:21:42','  2023-08-06 17:21:42',20,12,2,25000,'delivered'),
(36,'2023-08-05 17:22:06','  2023-08-07 17:22:06',20,12,2,1800,'delivered'),
(37,'2023-08-06 17:22:24','  2023-08-08 17:22:24',20,12,2,150,'delivered'),
(38,'2023-08-07 17:22:48','  2023-08-09 17:22:48',20,12,2,1750,'delivered'),
(39,'2023-08-08 17:23:12','  2023-08-10 17:23:12',20,12,2,1400,'delivered'),
(40,'2023-08-09 17:23:43','  2023-08-11 17:23:43',20,12,2,16100,'delivered'),
(41,'2023-08-10 17:24:39','  2023-08-12 17:24:39',21,13,2,20400,'delivered'),
(42,'2023-08-11 17:24:58','  2023-08-13 17:24:58',21,13,2,250,'delivered'),
(43,'2023-08-12 17:25:14','  2023-08-14 17:25:14',21,13,2,320,'delivered'),
(44,'2023-08-13 17:25:34','  2023-08-15 17:25:34',21,13,2,320,'delivered'),
(45,'2023-08-14 17:25:55','  2023-08-16 17:25:55',21,13,2,400,'delivered'),
(46,'2023-08-15 17:26:29','  2023-08-17 17:26:29',21,13,2,4200,'delivered'),
(47,'2023-08-16 17:26:49','  2023-08-18 17:26:49',21,13,2,600,'delivered'),
(48,'2023-08-17 17:27:13','  2023-08-19 17:27:13',21,13,2,600,'delivered'),
(49,'2023-08-18 17:27:41','  2023-08-20 17:27:41',21,13,2,5600,'delivered'),
(50,'2023-08-19 17:28:10','  2023-08-21 17:28:10',21,13,2,1150,'delivered'),
(51,'2023-08-20 17:29:10','  2023-08-22 17:29:10',22,14,3,25400,'delivered'),
(52,'2023-08-21 17:29:38','  2023-08-23 17:29:38',22,14,3,750,'delivered'),
(53,'2023-08-22 17:30:03','  2023-08-24 17:30:03',22,14,3,2500,'delivered'),
(54,'2023-08-23 17:30:25','  2023-08-25 17:30:25',22,14,3,1050,'delivered'),
(55,'2023-08-24 17:30:57','  2023-08-26 17:30:57',22,14,3,720,'delivered'),
(56,'2023-08-25 17:31:44','  2023-08-27 17:31:44',23,15,3,10620,'delivered'),
(57,'2023-08-26 17:32:04','  2023-08-28 17:32:04',23,15,3,800,'delivered'),
(58,'2023-08-27 17:32:42','  2023-08-29 17:32:42',23,15,3,960,'delivered'),
(59,'2023-08-28 17:33:31','  2023-08-30 17:33:31',23,15,3,250,'delivered'),
(60,'2023-08-29 17:33:32','  2023-09-01 17:33:32',23,15,3,250,'delivered'),
(61,'2023-08-30 17:34:44','  2023-09-02 17:34:44',24,16,3,29200,'delivered'),
(62,'2023-08-31 17:34:58','  2023-09-03 17:34:58',24,16,3,2500,'delivered'),
(63,'2023-09-01 17:35:21','  2023-09-04 17:35:21',24,16,3,250,'delivered'),
(64,'2023-09-02 17:35:36','  2023-09-05 17:35:36',24,16,3,150,'delivered'),
(65,'2023-09-03 17:35:56','  2023-09-06 17:35:56',24,16,3,120,'delivered'),
(66,'2023-09-04 17:36:13','  2023-09-07 17:36:13',24,16,3,2500,'delivered'),
(67,'2023-09-05 17:36:36','  2023-09-08 17:36:36',24,16,3,2500,'delivered'),
(68,'2023-09-06 17:36:55','  2023-09-09 17:36:55',24,16,3,1400,'delivered'),
(69,'2023-09-07 17:37:15','  2023-09-10 17:37:15',24,16,3,900,'delivered'),
(70,'2023-09-08 17:37:59','  2023-09-11 17:37:59',25,17,5,21150,'delivered'),
(71,'2023-09-09 17:38:14','  2023-09-12 17:38:14',25,17,5,450,'delivered'),
(72,'2023-09-10 17:38:31','  2023-09-13 17:38:31',25,17,5,3000,'delivered'),
(73,'2023-09-11 17:38:50','  2023-09-14 17:38:50',25,17,5,250,'delivered'),
(74,'2023-09-12 17:39:22','  2023-09-15 17:39:22',25,17,5,150,'delivered'),
(75,'2023-09-13 17:40:00','  2023-09-16 17:40:00',25,17,5,300,'delivered'),
(76,'2023-09-14 17:40:52','  2023-09-17 17:40:52',26,18,5,10510,'delivered'),
(77,'2023-09-15 17:41:19','  2023-09-18 17:41:19',26,18,5,250,'delivered'),
(78,'2023-09-16 17:41:52','  2023-09-19 17:41:52',26,18,5,220,'delivered'),
(79,'2023-09-17 17:42:28','  2023-09-20 17:42:28',26,18,5,360,'delivered'),
(80,'2023-09-18 17:42:51','  2023-09-21 17:42:51',26,18,5,1050,'delivered'),
(81,'2023-09-19 17:43:41','  2023-09-22 17:43:41',27,19,5,31850,'delivered'),
(82,'2023-09-20 17:44:07','  2023-09-23 17:44:07',27,19,5,1300,'delivered'),
(83,'2023-09-21 17:44:47','  2023-09-24 17:44:47',27,19,5,2250,'delivered'),
(84,'2023-09-22 17:45:03','  2023-09-25 17:45:03',27,19,5,700,'delivered'),
(85,'2023-09-23 17:45:29','  2023-09-26 17:45:29',27,19,5,2820,'delivered'),
(86,'2023-09-24 17:45:45','  2023-09-27 17:45:45',27,19,5,300,'delivered'),
(87,'2023-09-25 17:46:19','  2023-09-28 17:46:19',27,19,5,4350,'delivered'),
(88,'2023-09-26 17:46:35','  2023-09-29 17:46:35',27,19,5,750,'delivered'),
(89,'2023-09-27 17:46:58','  2023-09-30 17:46:58',27,19,5,3220,'delivered'),
(90,'2023-09-28 17:47:24','  2023-10-01 17:47:24',27,19,5,3400,'delivered');




INSERT INTO orderdetails VALUES   
(1,2,2,4),
(2,2,17,4),
(3,2,32,4),
(4,2,47,4),
(5,2,62,4),
(6,2,77,4),
(7,3,5,1),
(8,3,16,1),
(9,4,3,1),
(10,4,14,1),
(11,5,56,1),
(12,5,62,10),
(13,6,1,5),
(14,6,16,5),
(15,6,31,5),
(16,6,46,5),
(17,6,76,5),
(18,7,12,1),
(19,7,70,1),
(20,8,7,1),
(21,8,8,2),
(22,9,42,1),
(23,9,44,2),
(24,10,78,1),
(25,10,80,1),
(26,11,20,1),
(27,12,3,4),
(28,12,18,4),
(29,12,63,4),
(30,13,34,2),
(31,13,32,1),
(32,14,70,2),
(33,14,62,1),
(34,15,30,1),
(35,16,28,1),
(36,17,26,1),
(37,18,4,1),
(38,18,19,1),
(39,18,34,1),
(40,19,20,1),
(41,20,74,1),
(42,20,76,1),
(43,21,35,5),
(44,21,50,5),
(45,22,42,6),
(46,22,44,5),
(47,23,32,2),
(48,23,31,2),
(49,24,25,2),
(50,25,18,1),
(51,26,6,2),
(52,26,21,2),
(53,26,36,2),
(54,26,51,2),
(55,26,66,2),
(56,26,80,2),
(57,26,20,1),
(58,27,48,1),
(59,28,21,3),
(60,29,86,2),
(61,30,29,3),
(62,31,7,2),
(63,31,22,2),
(64,31,37,2),
(65,31,52,2),
(66,31,67,2),
(67,31,81,2),
(68,31,12,1),
(69,32,43,10),
(70,33,64,6),
(71,34,8,5),
(72,34,23,5),
(73,34,38,5),
(74,34,53,5),
(75,34,68,5),
(76,34,82,5),
(77,34,3,1),
(78,35,27,10),
(79,36,72,6),
(80,37,46,1),
(81,38,6,7),
(82,39,78,2),
(83,40,34,10),
(84,41,9,4),
(85,41,24,4),
(86,41,39,4),
(87,41,54,4),
(88,41,69,4),
(89,41,83,4),
(90,41,18,1),
(91,42,38,1),
(92,43,68,1),
(93,44,68,1),
(94,45,35,1),
(95,46,62,4),
(96,47,42,1),
(97,48,16,5),
(98,49,14,4),
(99,50,45,1),
(100,51,10,4),
(101,51,25,4),
(102,51,40,4),
(103,51,55,4),
(104,51,70,4),
(105,51,84,4),
(106,51,88,1),
(107,52,69,5),
(108,53,27,1),
(109,54,23,1),
(110,55,54,3),
(111,56,11,1),
(112,56,26,1),
(113,56,40,1),
(114,56,56,1),
(115,56,71,1),
(116,56,85,1),
(117,56,31,1),
(118,57,86,1),
(119,58,29,3),
(120,59,38,1),
(121,60,38,1),
(122,61,12,5),
(123,61,27,5),
(124,61,42,5),
(125,61,57,5),
(126,61,72,5),
(127,61,86,5),
(128,61,90,5),
(129,61,5,1),
(130,62,5,1),
(131,63,6,1),
(132,64,46,1),
(133,65,8,1),
(134,66,31,1),
(135,67,27,1),
(136,68,14,1),
(137,69,10,2),
(138,70,13,2),
(139,70,28,2),
(140,70,43,2),
(141,70,58,2),
(142,70,73,2),
(143,70,87,2),
(144,70,91,2),
(145,70,32,1),
(146,71,10,1),
(147,72,25,1),
(148,73,38,1),
(149,74,46,1),
(150,75,47,1),
(151,76,14,2),
(152,76,29,2),
(153,76,44,2),
(154,76,59,2),
(155,76,74,2),
(156,76,88,2),
(157,76,92,2),
(158,76,56,1),
(159,77,66,1),
(160,78,12,1),
(161,79,54,1),
(162,79,56,1),
(163,80,21,1),
(164,80,50,1),
(165,81,15,5),
(166,81,30,5),
(167,81,45,5),
(168,81,60,5),
(169,81,75,5),
(170,82,20,1),
(171,82,23,1),
(172,83,42,1),
(173,83,44,3),
(174,84,78,1),
(175,85,29,1),
(176,85,31,1),
(177,86,72,1),
(178,87,42,4),
(179,87,50,3),
(180,88,48,1),
(181,89,34,2),
(182,90,62,3),
(183,90,66,1);


INSERT INTO payments VALUES        
(1,' 2023-07-05 16:57:21','net banking','paid',111,2),
(2,' 2023-07-06 16:58:34','net banking','paid',112,3),
(3,' 2023-07-07 16:59:02','net banking','paid',113,4),
(4,' 2023-07-08 16:59:51','net banking','paid',114,5),
(5,' 2023-07-09 17:02:19','net banking','paid',115,6),
(6,' 2023-07-10 17:02:44','net banking','paid',116,7),
(7,' 2023-07-11 17:03:27','net banking','paid',117,8),
(8,' 2023-07-12 17:04:00','net banking','paid',118,9),
(9,' 2023-07-13 17:04:50','net banking','paid',119,10),
(10,' 2023-07-14 17:05:54','net banking','paid',120,11),
(11,' 2023-07-15 17:06:22','net banking','paid',121,12),
(12,' 2023-07-16 17:06:49','net banking','paid',122,13),
(13,' 2023-07-17 17:07:20','net banking','paid',123,14),
(14,' 2023-07-18 17:07:40','net banking','paid',124,15),
(15,' 2023-07-19 17:08:34','net banking','paid',125,16),
(16,' 2023-07-20 17:09:23','net banking','paid',126,17),
(17,' 2023-07-21 17:09:52','net banking','paid',127,18),
(18,' 2023-07-22 17:10:06','net banking','paid',128,19),
(19,' 2023-07-23 17:10:33','net banking','paid',129,20),
(20,' 2023-07-24 17:11:41','net banking','paid',130,21),
(21,' 2023-07-25 17:12:14','net banking','paid',131,22),
(22,' 2023-07-26 17:12:53','net banking','paid',132,23),
(23,' 2023-07-27 17:13:23','net banking','paid',133,24),
(24,' 2023-07-28 17:14:04','net banking','paid',134,25),
(25,' 2023-07-29 17:16:12','net banking','paid',135,26),
(26,' 2023-07-30 17:16:36','net banking','paid',136,27),
(27,' 2023-07-31 17:17:01','net banking','paid',137,28),
(28,' 2023-08-01 17:17:28','net banking','paid',138,29),
(29,' 2023-08-02 17:18:01','net banking','paid',139,30),
(30,' 2023-08-03 17:18:52','net banking','paid',140,31),
(31,' 2023-08-04 17:19:32','net banking','paid',141,32),
(32,' 2023-08-05 17:20:28','net banking','paid',142,33),
(33,' 2023-08-06 17:21:13','net banking','paid',143,34),
(34,' 2023-08-07 17:21:41','net banking','paid',144,35),
(35,' 2023-08-08 17:22:06','net banking','paid',145,36),
(36,' 2023-08-09 17:22:24','net banking','paid',146,37),
(37,' 2023-08-10 17:22:48','net banking','paid',147,38),
(38,' 2023-08-11 17:23:11','net banking','paid',148,39),
(39,' 2023-08-12 17:23:42','net banking','paid',149,40),
(40,' 2023-08-13 17:24:38','net banking','paid',150,41),
(41,' 2023-08-14 17:24:57','net banking','paid',151,42),
(42,' 2023-08-15 17:25:14','net banking','paid',152,43),
(43,' 2023-08-16 17:25:34','net banking','paid',153,44),
(44,' 2023-08-17 17:25:54','net banking','paid',154,45),
(45,' 2023-08-18 17:26:28','net banking','paid',155,46),
(46,' 2023-08-19 17:26:48','net banking','paid',156,47),
(47,' 2023-08-20 17:27:12','net banking','paid',157,48),
(48,' 2023-08-21 17:27:40','net banking','paid',158,49),
(49,' 2023-08-22 17:28:10','net banking','paid',159,50),
(50,' 2023-08-23 17:29:09','net banking','paid',160,51),
(51,' 2023-08-24 17:29:38','net banking','paid',161,52),
(52,' 2023-08-25 17:30:02','net banking','paid',162,53),
(53,' 2023-08-26 17:30:25','net banking','paid',163,54),
(54,' 2023-08-27 17:30:56','net banking','paid',164,55),
(55,' 2023-08-28 17:31:44','net banking','paid',165,56),
(56,' 2023-08-29 17:32:04','net banking','paid',166,57),
(57,' 2023-08-30 17:32:41','net banking','paid',167,58),
(58,' 2023-08-31 17:33:31','net banking','paid',168,59),
(59,' 2023-09-01 17:33:33','net banking','paid',169,60),
(60,' 2023-09-02 17:34:43','net banking','paid',170,61),
(61,' 2023-09-03 17:34:57','net banking','paid',171,62),
(62,' 2023-09-04 17:35:20','net banking','paid',172,63),
(63,' 2023-09-05 17:35:36','net banking','paid',173,64),
(64,' 2023-09-06 17:35:55','net banking','paid',174,65),
(65,' 2023-09-07 17:36:13','net banking','paid',175,66),
(66,' 2023-09-08 17:36:35','net banking','paid',176,67),
(67,' 2023-09-09 17:36:54','net banking','paid',177,68),
(68,' 2023-09-10 17:37:15','net banking','paid',178,69),
(69,' 2023-09-11 17:37:58','net banking','paid',179,70),
(70,' 2023-09-12 17:38:14','net banking','paid',180,71),
(71,' 2023-09-13 17:38:31','net banking','paid',181,72),
(72,' 2023-09-14 17:38:50','net banking','paid',182,73),
(73,' 2023-09-15 17:39:21','net banking','paid',183,74),
(74,' 2023-09-16 17:40:00','net banking','paid',184,75),
(75,' 2023-09-17 17:40:51','net banking','paid',185,76),
(76,' 2023-09-18 17:41:19','net banking','paid',186,77),
(77,' 2023-09-19 17:41:51','net banking','paid',187,78),
(78,' 2023-09-20 17:42:27','net banking','paid',188,79),
(79,' 2023-09-21 17:42:51','net banking','paid',189,80),
(80,' 2023-09-22 17:43:40','net banking','paid',190,81),
(81,' 2023-09-23 17:44:07','net banking','paid',191,82),
(82,' 2023-09-24 17:44:47','net banking','paid',192,83),
(83,' 2023-09-25 17:45:02','net banking','paid',193,84),
(84,' 2023-09-26 17:45:28','net banking','paid',194,85),
(85,' 2023-09-27 17:45:44','net banking','paid',195,86),
(86,' 2023-09-28 17:46:19','net banking','paid',196,87),
(87,' 2023-09-29 17:46:34','net banking','paid',197,88),
(88,' 2023-09-30 17:46:57','net banking','paid',198,89),
(89,' 2023-10-01 17:47:24','net banking','paid',199,90);


INSERT INTO shipperorders(shipperid,orderid) VALUES 
(2,2), (2,3), (2,4), (2,5), (2,6), (2,7), (2,8), (2,9), (2,10), (2,11), (2,12), (2,13), (2,14), (2,15),
(4,16), (4,17), (4,18), (4,19), (4,20), (4,21), (4,22), (4,23), (4,24), (4,25), (4,26), (4,27), (4,28), (4,29), (4,30),
(3,31), (3,32), (3,33), (3,34), (3,35), (3,36), (3,37), (3,38), (3,39), (3,40), (3,41), (3,42), (3,43), (3,44), (3,45), (3,46), (3,47), (3,48), (3,49), (3,50),
(1,51), (1,52), (1,53), (1,54), (1,55), (1,56), (1,57), (1,58), (1,59), (1,60), (1,61), (1,62), (1,63), (1,64), (1,65), (1,66), (1,67), (1,68), (1,69),
(5,70), (5,71), (5,72), (5,73), (5,74), (5,75), (5,76), (5,77), (5,78), (5,79), (5,80), (5,81), (5,82), (5,83), (5,84), (5,85), (5,86), (5,87), (5,88), (5,89), (5,90);

-- CARTS DATA
INSERT INTO carts(customerid) VALUES (2);
INSERT INTO carts(customerid) VALUES (3);
INSERT INTO carts(customerid) VALUES (15);
INSERT INTO carts(customerid) VALUES (16);
INSERT INTO carts(customerid) VALUES (17);
INSERT INTO carts(customerid) VALUES (18);
INSERT INTO carts(customerid) VALUES (19);
INSERT INTO carts(customerid) VALUES (20);
INSERT INTO carts(customerid) VALUES (21);
INSERT INTO carts(customerid) VALUES (22);
INSERT INTO carts(customerid) VALUES (23);
INSERT INTO carts(customerid) VALUES (24);
INSERT INTO carts(customerid) VALUES (25);
INSERT INTO carts(customerid) VALUES (26);
INSERT INTO carts(customerid) VALUES (27);



-- CARTS ITEMS DATA
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(1,1,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(2,2,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(3,3,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(4,4,1);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(5,5,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(6,6,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(7,7,2);

INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(8,8,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(9,9,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(10,10,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(11,11,1);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(12,12,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(13,13,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(14,14,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(15,15,5);

INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(1,16,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(2,17,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(3,18,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(4,19,1);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(5,20,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(6,21,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(7,22,2);

INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(8,23,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(9,24,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(10,25,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(11,26,1);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(12,27,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(13,28,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(14,29,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(15,30,5);




INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(1,31,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(2,32,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(3,33,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(4,34,1);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(5,35,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(6,36,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(7,37,2);

INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(8,38,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(9,39,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(10,40,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(11,41,1);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(12,42,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(13,43,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(14,44,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(15,45,5);

INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(1,46,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(2,47,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(3,48,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(4,49,1);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(5,50,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(6,51,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(7,52,2);

INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(8,53,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(9,54,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(10,55,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(11,56,1);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(12,57,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(13,58,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(14,59,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(15,60,5);

INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(1,61,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(2,62,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(3,63,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(4,64,1);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(5,65,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(6,66,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(7,67,2);

INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(8,68,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(9,69,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(10,70,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(11,71,1);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(12,72,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(13,73,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(14,74,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(15,75,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(1,76,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(2,77,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(3,78,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(4,78,1);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(5,79,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(6,80,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(7,81,2);

INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(8,82,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(9,83,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(10,84,4);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(11,85,1);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(12,86,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(13,87,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(14,88,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(15,89,5);


INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(12,90,5);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(13,91,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(14,92,2);
INSERT INTO cartitems(cartid,productdetailsid ,quantity) VALUES(15,93,5);



-- PAYMENTS DATA
-- INSERT INTO payments(date,mode,paymentstatus,transactionid,orderid) VALUES('2022-03-08 12:08:19','net banking','paid',1,1);
-- INSERT INTO payments(date,mode,paymentstatus,transactionid,orderid) VALUES('2022-03-08 12:08:19','net banking','paid',2,2);

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
INSERT INTO questions(description,categoryid) VALUES('How can I market my organic and sustainably grown products effectively?',4);


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
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,1,'2023-09-01');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,2,'2023-09-01');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,3,'2023-09-01');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,4,'2023-09-01');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,5,'2023-09-02');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,6,'2023-09-02');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (19,7,'2023-09-02');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (20,8,'2023-09-03');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (21,9,'2023-09-03');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (22,10,'2023-09-03');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (23,11,'2023-09-03');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (24,12,'2023-09-03');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (25,13,'2023-09-03');



INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,14,'2023-09-03');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,15,'2023-09-04');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,16,'2023-09-04');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,17,'2023-09-04');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,18,'2023-09-05');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,19,'2023-09-05');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,20,'2023-09-06');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (19,21,'2023-09-07');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (20,22,'2023-09-08');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (21,13,'2023-09-09');




INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (22,23,'2023-09-010');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (23,24,'2023-09-010');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (24,25,'2023-09-11');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (25,26,'2023-09-12');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,27,'2023-09-12');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,28,'2023-09-13');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,29,'2023-09-13');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,30,'2023-09-13');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,31,'2023-09-14');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,32,'2023-09-14');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (19,33,'2023-09-14');



INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (20,34,'2023-09-15');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (21,35,'2023-09-16');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (22,36,'2023-09-17');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (23,37,'2023-09-17');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (24,38,'2023-09-17');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (25,39,'2023-09-17');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,40,'2023-09-18');



INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,41,'2023-09-18');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,42,'2023-09-19');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,43,'2023-09-19');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,44,'2023-09-20');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,45,'2023-09-20');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,46,'2023-09-20');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (19,47,'2023-09-20');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (20,48,'2023-09-21');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (21,49,'2023-09-21');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (22,50,'2023-09-21');



INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (23,51,'2023-09-21');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (24,52,'2023-09-22');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (25,53,'2023-09-22');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,54,'2023-09-23');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,55,'2023-09-23');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,56,'2023-09-23');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,57,'2023-09-23');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,58,'2023-09-23');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,59,'2023-09-24');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (19,60,'2023-09-24');


INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (20,61,'2023-09-24');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (21,62,'2023-09-24');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (22,63,'2023-09-24');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (23,64,'2023-09-24');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (24,65,'2023-09-25');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (25,66,'2023-09-25');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,67,'2023-09-25');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,68,'2023-09-25');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,69,'2023-09-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,70,'2023-09-26');



INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,71,'2023-09-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,72,'2023-09-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (19,73,'2023-09-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (20,74,'2023-09-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (21,75,'2023-09-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (22,76,'2023-09-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (23,77,'2023-09-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (24,78,'2023-09-26');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (25,79,'2023-09-27');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,80,'2023-09-27');


INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,81,'2023-09-27');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,82,'2023-09-27');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,83,'2023-09-27');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,84,'2023-09-28');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,85,'2023-09-28');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (19,86,'2023-09-29');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (20,87,'2023-09-29');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (21,88,'2023-09-29');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (22,89,'2023-09-29');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (23,90,'2023-09-29');


INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (24,91,'2023-09-29');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (25,92,'2023-09-29');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,93,'2023-09-30');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,94,'2023-09-30');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (15,95,'2023-09-30');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (16,96,'2023-09-30');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (17,97,'2023-09-30');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (18,98,'2023-09-30');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (26,99,'2023-09-30');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (27,100,'2023-09-30');

-- SME TABLE DATA
INSERT INTO subjectmatterexperts(expertise,userid) VALUES('crop related information',8);
INSERT INTO subjectmatterexperts(expertise,userid) VALUES('soil related information',9);
INSERT INTO subjectmatterexperts(expertise,userid) VALUES('soil related information',36);
INSERT INTO subjectmatterexperts(expertise,userid) VALUES('soil related information',37);
INSERT INTO subjectmatterexperts(expertise,userid) VALUES('soil related information',38);
INSERT INTO subjectmatterexperts(expertise,userid) VALUES('soil related information',39);
INSERT INTO subjectmatterexperts(expertise,userid) VALUES('soil related information',40);



-- ANSWERS TABLE DATA

INSERT INTO answers(description,questionid,likes) VALUES('You can enhance soil fertility through practices like adding organic matter (compost or manure),
                                                                     conducting soil tests to determine nutrient needs, and practicing crop rotation.',1,7);
INSERT INTO answers(description,questionid,likes) VALUES('In organic farming, you can use methods like companion planting, beneficial insects, and organic pesticides to control pests and weeds without synthetic chemicals.',2,6);
INSERT INTO answers(description,questionid,likes)VALUES(' Implement water-efficient irrigation methods such as drip irrigation or sprinkler systems, and schedule irrigation based on the specific water needs of your crops.',3,5);
INSERT INTO answers(description,questionid,likes) VALUES('Choose crop varieties that are well-suited to your local climate, soil type, and disease resistance to optimize yield and reduce risks.',4,13);
INSERT INTO answers(description,questionid,likes) VALUES('You can minimize post-harvest losses by using proper storage facilities, maintaining the right temperature and humidity levels, and adopting good handling practices.',5,7);
INSERT INTO answers(description,questionid,likes) VALUES(' Many governments offer programs, grants, and subsidies to encourage sustainable and environmentally friendly farming practices. Its worth exploring these opportunities.',6,6);
INSERT INTO answers(description,questionid,likes) VALUES(' Transitioning to organic farming may involve gradually reducing chemical inputs, adopting organic certification standards, and learning about organic pest and weed management techniques.',7,8);
INSERT INTO answers(description,questionid,likes) VALUES(' Strategies to improve profitability may include diversifying crops, exploring niche markets, reducing production costs, and optimizing resource use.',8,7);
INSERT INTO answers(description,questionid,likes) VALUES('Signs of nutrient deficiencies can include yellowing leaves, stunted growth, and poor fruiting. Address them by applying the appropriate nutrients through fertilization.',9,6);
INSERT INTO answers(description,questionid,likes) VALUES('Climate change can affect growing seasons and precipitation patterns. To adapt, consider adjusting planting dates, selecting climate-resilient crops, and implementing efficient water management.',10,9);


INSERT INTO answers(description,questionid,likes) VALUES('Improving livestock health involves providing proper nutrition, clean water, shelter, and regular veterinary care. Its also important to manage stress factors and ensure good sanitation practices.',11,9);
INSERT INTO answers(description,questionid,likes) VALUES('Effective grazing management includes rotational grazing, maintaining pasture health, and ensuring access to fresh forage to optimize your livestocks nutrition.',12,7);
INSERT INTO answers(description,questionid,likes)VALUES('Look for signs like changes in behavior, weight loss, or abnormal physical symptoms. Consult with a veterinarian for a proper diagnosis and treatment plan.',13,9);
INSERT INTO answers(description,questionid,likes) VALUES('To improve livestock genetics, consider selective breeding, artificial insemination, or using high-quality breeding stock to enhance desirable traits in your herd or flock.',14,6);
INSERT INTO answers(description,questionid,likes) VALUES('Proper handling and transportation techniques help reduce stress and ensure the safety of both animals and handlers. Learn about low-stress handling methods and comply with transportation regulations.',15,8);
INSERT INTO answers(description,questionid,likes) VALUES('Effective marketing strategies may include identifying target markets, establishing relationships with buyers, and utilizing online platforms or local markets to sell your livestock and products.',16,10);
INSERT INTO answers(description,questionid,likes) VALUES('Consider factors like animal comfort, ventilation, waste management, and biosecurity when designing or updating your livestock facilities.',17,8);
INSERT INTO answers(description,questionid,likes) VALUES('Technology can improve livestock farming through tools like automated feeding systems, health monitoring devices, and data analytics to enhance productivity and animal welfare.',18,8);
INSERT INTO answers(description,questionid,likes) VALUES('Sustainable livestock farming practices may involve conserving water, reducing waste, using renewable energy sources, and adopting rotational grazing to preserve soil health.',19,5);
INSERT INTO answers(description,questionid,likes) VALUES('Explore government grants, subsidies, and agricultural extension services that may offer financial support and guidance to improve your livestock farming operation.',20,13);


INSERT INTO answers(description,questionid,likes) VALUES('Stay updated on innovations like autonomous tractors, precision planting systems, and remote monitoring technology to see how they can improve your farms efficiency.',21,4);
INSERT INTO answers(description,questionid,likes) VALUES('Regular maintenance, proper calibration, and following manufacturer guidelines for equipment use are essential to keep your farm machinery in top working condition.',22,8);
INSERT INTO answers(description,questionid,likes)VALUES('Explore financing options, including loans, leasing, or government programs, that can help you acquire the necessary equipment and technology for your farm.',23,2);
INSERT INTO answers(description,questionid,likes) VALUES('Seek advice from equipment dealers or agricultural experts who can assess your farms requirements and recommend suitable machinery.',24,9);
INSERT INTO answers(description,questionid,likes) VALUES('You can use farm management software to collect and analyze data from sensors and machinery, enabling you to make informed decisions about planting, irrigation, and more.',25,7);
INSERT INTO answers(description,questionid,likes) VALUES(' Proper storage includes cleaning, covering, and securing machinery to protect it from the elements and potential theft.',26,9);
INSERT INTO answers(description,questionid,likes) VALUES(' Learn about basic troubleshooting techniques for common machinery problems, such as engine issues or hydraulic system malfunctions, to minimize downtime.',27,8);
INSERT INTO answers(description,questionid,likes) VALUES('Look for equipment rental services in your area, which can be cost-effective for occasional or specialized tasks.',28,7);
INSERT INTO answers(description,questionid,likes) VALUES('Ensure all operators receive proper training and follow safety protocols, including wearing appropriate protective gear and conducting pre-operation checks.',29,7);
INSERT INTO answers(description,questionid,likes) VALUES('Explore the benefits of technology like automated feeders, which can improve feed efficiency and reduce labor while ensuring proper nutrition for your livestock.',30,4);


INSERT INTO answers(description,questionid,likes) VALUES('Organic farming avoids synthetic chemicals and genetically modified organisms (GMOs) and focuses on soil health, crop rotation, and organic fertilizers to promote sustainability.',31,7);
INSERT INTO answers(description,questionid,likes) VALUES('The transition typically involves ceasing the use of synthetic pesticides and fertilizers, adopting organic practices, and undergoing a certification process. Consult with organic farming experts for guidance.',32,2);
INSERT INTO answers(description,questionid,likes)VALUES('Organic pest control methods include beneficial insects, companion planting, neem oil, and organic pesticides that are approved for organic farming.',33,12);
INSERT INTO answers(description,questionid,likes) VALUES('Practices such as cover cropping, composting, reduced tillage, and crop rotation can enhance soil health and fertility in organic farming.',34,9);
INSERT INTO answers(description,questionid,likes) VALUES(' Strategies include mulching, mechanical cultivation, flame weeding, and using cover crops that suppress weeds.',35,8);
INSERT INTO answers(description,questionid,likes) VALUES('  Sustainable farming practices promote long-term environmental stewardship, conserve natural resources, reduce chemical inputs, and improve soil and water quality.',36,7);
INSERT INTO answers(description,questionid,likes) VALUES(' Implement water-efficient irrigation methods, such as drip or pivot irrigation, and use soil moisture monitoring systems to optimize water use.',37,6);
INSERT INTO answers(description,questionid,likes) VALUES(' Organic fertilizers like compost, manure, bone meal, and fish emulsion can provide essential nutrients to crops without synthetic chemicals.',38,5);
INSERT INTO answers(description,questionid,likes) VALUES('Sustainable livestock management involves rotational grazing, proper animal welfare practices, and using organic feed and forage whenever possible.',39,4);
INSERT INTO answers(description,questionid,likes) VALUES('Utilize organic certification labels, participate in local farmers markets, and establish partnerships with restaurants and retailers that support sustainable and organic products.',40,12);


INSERT INTO answers(description,questionid,likes) VALUES('Creating a comprehensive budget involves listing all expenses (such as seeds, labor, and equipment maintenance) and estimating income from crop sales, livestock, and other sources.',41,12);
INSERT INTO answers(description,questionid,likes) VALUES('Key financial ratios include the debt-to-equity ratio, the current ratio, and the return on assets. These ratios can provide insights into your farms financial stability and efficiency.',42,11);
INSERT INTO answers(description,questionid,likes)VALUES(' Assess your resources, market demand, and production capabilities to determine the right size and scope for your farm. Consider factors like available land and labor, as well as your financial goals.',43,10);
INSERT INTO answers(description,questionid,likes) VALUES(' Effective marketing strategies may include developing a strong online presence, participating in farmers markets, establishing relationships with restaurants and retailers, and utilizing social media.',44,9);
INSERT INTO answers(description,questionid,likes) VALUES('  Negotiating fair contracts involves understanding market prices, product quality standards, and the terms and conditions of agreements. Seek legal advice if necessary.',45,8);
INSERT INTO answers(description,questionid,likes) VALUES(' Strategies include maintaining a cash reserve, securing lines of credit, and aligning expenses with revenue to avoid cash flow shortages.',46,5);
INSERT INTO answers(description,questionid,likes) VALUES(' Consult with a tax advisor to understand the tax advantages and disadvantages of different business structures and choose the one that suits your farms needs.',47,7);
INSERT INTO answers(description,questionid,likes) VALUES('Diversification can include adding new crops or livestock, offering agritourism activities, or producing value-added products like jams or cheeses.',48,4);
INSERT INTO answers(description,questionid,likes) VALUES('Transitioning may involve initial investment in soil health and organic certification. Assess the long-term economic benefits and consider grants or subsidies available for sustainable practices.',49,8);
INSERT INTO answers(description,questionid,likes) VALUES('Look for agricultural extension services, farm management courses, and government agencies that offer guidance and resources to help farmers manage their farm businesses effectively.',50,7);


INSERT INTO answers(description,questionid,likes) VALUES(' Consider factors like temperature, precipitation, soil type, and local market demand when selecting crops or livestock breeds that are well-suited to your region.',51,8);
INSERT INTO answers(description,questionid,likes) VALUES('Solutions may include rainwater harvesting, efficient irrigation systems, and drought-resistant crop varieties to optimize water use during dry spells.',52,6);
INSERT INTO answers(description,questionid,likes)VALUES(' Frost protection methods include using frost blankets, wind machines, and selecting frost-tolerant crop varieties.',53,3);
INSERT INTO answers(description,questionid,likes) VALUES('Practices like contour farming, terracing, and cover cropping can help prevent soil erosion on slopes.',54,2);
INSERT INTO answers(description,questionid,likes) VALUES(' Timing your planting and harvesting to align with the rainy season can optimize crop growth and yield.',55,4);
INSERT INTO answers(description,questionid,likes) VALUES(' Factors to consider include greenhouse design, heating options, and insulation to create a suitable microclimate for your crops.',56,8);
INSERT INTO answers(description,questionid,likes) VALUES(' Soil amendments like gypsum, proper drainage systems, and salt-tolerant crop varieties can help address salt-affected soils.',57,7);
INSERT INTO answers(description,questionid,likes) VALUES(' Humid regions may have issues with fungal diseases and insect pests. Integrated pest management (IPM) practices, proper sanitation, and disease-resistant crop varieties can help manage these challenges.',58,8);
INSERT INTO answers(description,questionid,likes) VALUES(' Crop rotation and diversification can help spread risk and reduce the impact of adverse weather conditions on the farm.',59,6);
INSERT INTO answers(description,questionid,likes) VALUES(' Local farmer networks, agricultural cooperatives, and extension services can provide opportunities to connect with other farmers and share insights about regional farming challenges and solutions.',60,5);




INSERT INTO answers(description,questionid,likes) VALUES(' Key safety measures include providing training, using protective equipment, maintaining machinery, and establishing safety protocols for tasks like handling chemicals or working with livestock.',61,9);
INSERT INTO answers(description,questionid,likes) VALUES('Regulations may vary by location, but they often cover areas like worker safety, chemical handling, and food safety. Consult with local agricultural agencies or authorities to understand and adhere to relevant regulations.',62,18);
INSERT INTO answers(description,questionid,likes)VALUES(' Implement safety practices like equipment inspections, proper machine guarding, and safe operating procedures. Provide training to all personnel operating machinery.',63,16);
INSERT INTO answers(description,questionid,likes) VALUES(' Establish child safety guidelines, including restricted access to hazardous areas, supervision, and age-appropriate tasks for children.',64,15);
INSERT INTO answers(description,questionid,likes) VALUES('Practices like maintaining firebreaks, proper storage of flammable materials, and having firefighting equipment on hand can help reduce fire risks.',65,13);
INSERT INTO answers(description,questionid,likes) VALUES('  Biosecurity measures may include quarantine for new animals, proper sanitation, and limiting visitor access to prevent the spread of diseases.',66,12);
INSERT INTO answers(description,questionid,likes) VALUES('  Implement food safety practices such as proper handling, storage, and labeling of farm products, and consider obtaining any necessary food safety certifications.',67,11);
INSERT INTO answers(description,questionid,likes) VALUES('  Yes, safety precautions include proper storage, labeling, and handling procedures for chemicals. Follow the manufacturers instructions and local regulations.',68,14);
INSERT INTO answers(description,questionid,likes) VALUES('Properly store and dispose of hazardous materials like pesticides, chemicals, and used oil according to local regulations and guidelines.',69,12);
INSERT INTO answers(description,questionid,likes) VALUES('Look for local agricultural extension services, farm safety organizations, and training programs that offer guidance and support for farm safety and regulatory compliance.',70,23);




INSERT INTO answers(description,questionid,likes) VALUES('Look for agricultural extension programs, research institutions, and industry publications that offer information on cutting-edge farming practices.',71,8);
INSERT INTO answers(description,questionid,likes) VALUES(' Many agricultural colleges and organizations offer courses and programs tailored to farmers interested in transitioning to organic farming.',72,7);
INSERT INTO answers(description,questionid,likes)VALUES('Explore local workshops, online courses, and resources provided by sustainable agriculture organizations to learn about these practices.',73,8);
INSERT INTO answers(description,questionid,likes) VALUES(' Some training programs may offer financial incentives or scholarships. Additionally, check with agricultural agencies and organizations for funding opportunities.',74,7);
INSERT INTO answers(description,questionid,likes) VALUES(' Look for local mentorship programs or agricultural associations that facilitate connections between experienced and aspiring farmers.',75,6);
INSERT INTO answers(description,questionid,likes) VALUES('Farm business management courses typically cover topics such as budgeting, marketing, record-keeping, and risk management.',76,5);
INSERT INTO answers(description,questionid,likes) VALUES(' Reach out to local farms, agricultural colleges, and organizations that offer apprenticeship programs to gain practical experience.',77,4);
INSERT INTO answers(description,questionid,likes) VALUES(' Farming cooperatives and associations can provide networking, support, and educational opportunities. Search online or ask fellow farmers for recommendations.',78,17);
INSERT INTO answers(description,questionid,likes) VALUES(' Some government programs may provide grants or tax incentives to support farmers education and training efforts.',79,15);
INSERT INTO answers(description,questionid,likes) VALUES('Time management and prioritization are key. Allocate dedicated time for learning, and consider online or flexible training options to fit your schedule.',80,14);



INSERT INTO answers(description,questionid,likes) VALUES(' Specialty farming focuses on the production of unique or niche crops, products, or livestock that cater to specific markets or consumer preferences, often deviating from traditional mainstream agriculture.',81,5);
INSERT INTO answers(description,questionid,likes) VALUES(' Research local market demands, consumer trends, and potential niche products to identify profitable opportunities for your farm.',82,7);
INSERT INTO answers(description,questionid,likes)VALUES('Specialty crop success involves understanding specific growing conditions, disease management, and finding the right market outlets for your products.',83,9);
INSERT INTO answers(description,questionid,likes) VALUES(' Yes, there are often certification processes and quality standards for specialty and organic products. Consult with certifying bodies and follow their guidelines for compliance.',84,7);
INSERT INTO answers(description,questionid,likes) VALUES(' Effective marketing strategies include branding, participating in farmers markets, building relationships with local chefs and restaurants, and utilizing social media and online platforms.',85,7);
INSERT INTO answers(description,questionid,likes) VALUES(' Challenges may include smaller market sizes, while benefits may include higher prices per unit and the preservation of rare or endangered breeds.',86,4);
INSERT INTO answers(description,questionid,likes) VALUES('  Explore agricultural extension services, specialty crop grants, and local agricultural organizations that offer resources and support for specialty farmers.',87,8);
INSERT INTO answers(description,questionid,likes) VALUES(' Diversification involves careful market research, risk assessment, and a well-thought-out business plan that includes both mainstream and specialty products.',88,13);
INSERT INTO answers(description,questionid,likes) VALUES('Specialty farming practices should align with sustainable and environmentally responsible methods, which may include organic or regenerative farming techniques.',89,12);
INSERT INTO answers(description,questionid,likes) VALUES(' Attend specialty crop conferences, subscribe to niche farming publications, and network with other specialty farmers to stay informed about trends and opportunities.',90,12);



INSERT INTO answers(description,questionid,likes) VALUES(' Consider implementing practices like crop rotation, cover cropping, and organic matter additions to enhance soil health and fertility.',91,2);
INSERT INTO answers(description,questionid,likes) VALUES('Implement best management practices (BMPs) like controlled drainage, nutrient management plans, and riparian buffer zones to reduce runoff and protect water quality.',92,3);
INSERT INTO answers(description,questionid,likes)VALUES(' Explore labor-saving technologies such as automated machinery and consider hiring seasonal or temporary workers to meet labor demands.',93,2);
INSERT INTO answers(description,questionid,likes) VALUES(' Focus on proper nutrition, housing, and disease prevention through vaccination and biosecurity measures to promote animal welfare and productivity.',94,5);
INSERT INTO answers(description,questionid,likes) VALUES(' Implement energy-efficient practices such as upgrading equipment, using renewable energy sources, and optimizing building insulation.',95,4);
INSERT INTO answers(description,questionid,likes) VALUES('Consider diversifying your income sources, exploring contract farming agreements, and using risk management tools like futures contracts to hedge against price fluctuations.',96,8);
INSERT INTO answers(description,questionid,likes) VALUES('  Develop resilient farming practices like drought-tolerant crops, efficient irrigation, and improved drainage systems to adapt to climate variability.',97,4);
INSERT INTO answers(description,questionid,likes) VALUES(' Build a strong online presence, participate in farmers  markets, offer farm-to-table experiences, and engage with community-supported agriculture (CSA) programs.',98,4);
INSERT INTO answers(description,questionid,likes) VALUES('Gradually transition by implementing organic practices, improving soil health, and seeking organic certification when ready.',99,12);
INSERT INTO answers(description,questionid,likes) VALUES('Create a comprehensive farm business plan, monitor key performance indicators, and continually seek opportunities for improvement and innovation.',100,10);

-- SME ANSWERS
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (1,'2023-09-02',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (2,'2023-09-02',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (3,'2023-09-02',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (4,'2023-09-02',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (5,'2023-09-03',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (6,'2023-09-03',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (7,'2023-09-03',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (8,'2023-09-04',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (9,'2023-09-04',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (10,'2023-09-05',1);

INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (11,'2023-09-05',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (12,'2023-09-05',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (13,'2023-09-06',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (14,'2023-09-06',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (15,'2023-09-07',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (16,'2023-09-07',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (17,'2023-09-09',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (18,'2023-09-10',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (19,'2023-09-10',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (20,'2023-09-11',2);

INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (21,'2023-09-11',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (22,'2023-09-11',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (23,'2023-09-12',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (24,'2023-09-12',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (25,'2023-09-13',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (26,'2023-09-13',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (27,'2023-09-14',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (28,'2023-09-14',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (29,'2023-09-15',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (30,'2023-09-15',3);

INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (31,'2023-09-16',4);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (32,'2023-09-16',4);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (33,'2023-09-17',4);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (34,'2023-09-17',4);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (35,'2023-09-18',4);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (36,'2023-09-19',4);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (37,'2023-09-19',4);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (38,'2023-09-20',4);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (39,'2023-09-20',4);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (40,'2023-09-20',4);

INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (41,'2023-09-21',5);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (42,'2023-09-21',5);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (43,'2023-09-22',5);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (44,'2023-09-22',5);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (45,'2023-09-23',5);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (46,'2023-09-23',5);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (47,'2023-09-24',5);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (48,'2023-09-24',5);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (49,'2023-09-25',5);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (50,'2023-09-25',5);

INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (51,'2023-09-26',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (52,'2023-09-26',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (53,'2023-09-26',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (54,'2023-09-27',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (55,'2023-09-27',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (56,'2023-09-28',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (57,'2023-09-28',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (58,'2023-09-29',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (59,'2023-09-29',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (60,'2023-09-29',1);

INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (61,'2023-09-30',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (62,'2023-09-30',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (63,'2023-09-30',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (64,'2023-09-30',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (65,'2023-09-30',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (66,'2023-09-30',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (67,'2023-09-30',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (68,'2023-10-01',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (69,'2023-10-01',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (70,'2023-10-01',2);

INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (71,'2023-10-01',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (72,'2023-10-01',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (73,'2023-10-02',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (74,'2023-10-02',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (75,'2023-10-02',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (77,'2023-10-02',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (79,'2023-10-03',3);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (80,'2023-10-03',3);

INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (81,'2023-10-03',6);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (82,'2023-10-03',6);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (83,'2023-10-03',6);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (84,'2023-10-03',6);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (85,'2023-10-03',6);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (86,'2023-10-03',6);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (87,'2023-10-03',6);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (88,'2023-10-03',6);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (89,'2023-10-04',6);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (90,'2023-10-04',6);

INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (91,'2023-10-04',7);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (92,'2023-10-04',7);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (93,'2023-10-04',7);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (94,'2023-10-04',7);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (95,'2023-10-04',7);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (96,'2023-10-04',7);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (97,'2023-10-05',7);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (98,'2023-10-05',7);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (99,'2023-10-05',7);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (100,'2023-10-05',7);
