-- Active: 1694968636816@@127.0.0.1@3306@ekrushi

INSERT INTO roles(name) VALUES ('Shop owner');
INSERT INTO roles(name) VALUES ('Customer');
INSERT INTO roles(name) VALUES ('Supplier');
INSERT INTO roles(name) VALUES ('Shipper');
INSERT INTO roles(name) VALUES ('SubjectMatterExpert');


INSERT INTO userroles(userid,roleid) VALUES (1,1);
INSERT INTO userroles(userid,roleid) VALUES (2,2);
INSERT INTO userroles(userid,roleid) VALUES (3,2);
INSERT INTO userroles(userid,roleid) VALUES (11,3);
INSERT INTO userroles(userid,roleid) VALUES (12,3);
INSERT INTO userroles(userid,roleid) VALUES (6,4);
INSERT INTO userroles(userid,roleid) VALUES (7,4);
INSERT INTO userroles(userid,roleid) VALUES (8,5);
INSERT INTO userroles(userid,roleid) VALUES (9,5);

 

 

INSERT INTO suppliers(corporateid,userid) VALUES(8,11);
INSERT INTO suppliers(corporateid,userid) VALUES(9,12);

-- SHIPPERS DATA
INSERT INTO shippers(corporateid,userid) VALUES(4,6);
INSERT INTO shippers(corporateid,userid) VALUES(5,7);


INSERT INTO categories(title,image) VALUES('seeds',"/assets/seed.jpeg");
INSERT INTO categories(title,image) VALUES('Agriculture implements',"/assets/Agri Equipments.jpeg");
INSERT INTO categories(title,image) VALUES('fertilizers',"/assets/fertilizer.jpeg");
INSERT INTO categories(title,image) VALUES('pesticides',"/assets/pestisides.jpeg");
INSERT INTO categories(title,image) VALUES('cattel feed',"/assets/cattle feed.jpeg");
INSERT INTO categories(title,image) VALUES('organic product',"/assets/organic.jpeg");
-- seeds
INSERT INTO products(title,description,image,categoryid) VALUES('oats','
For healthier and nutritiously growing food preferences, Oats are largely recommended by the topmost dieticians and nutritionists. Oats are the quintessential healthy food and make for an excellent and highly nutritious meal or even a snack. Being considered a superfood with an abundance of dietary fibres, beta-glucan, and several essential nutrients, Oats have become an everyday partner of every health-conscious individual. However, not everyone is familiar with the different kinds of Oats, having different generics, available in the market. Goodness and Wellness are the two common essences amongst all the different oats varieties. Let’s have a better understanding of the different types of oats, their key features, and nutrition components.

','/assets/oat.jfif',1);
INSERT INTO products(title,description,image,categoryid)VALUES('wheat','Wheat is the second most important staple food after rice consumed by 65% of the population in India and is likely to increase further due to changes in food habits. Wheat is mostly consumed in the form of ‘chapati’ in our country for which bread wheat is cultivated in nearly 95 per cent of the cropped area. ','/assets/wheat.jpg',1);
INSERT INTO products(title,description,image,categoryid) VALUES('corn','Corn is one of the world’s most productive and dominant crops. It is grown extensively as food for both humans and livestock, as a biofuel, and as a crude material in industry. Corn is the third largest plant-based food source in the world.','/assets/corn.jfif',1);

-- Agricultural Implements
INSERT INTO products(title,description,image,categoryid) VALUES('tractor','tractor high-power, low-speed traction vehicle and power unit mechanically similar to an automobile or truck but designed for use off the road. The two main types are wheeled, which is the earliest form, and continuous track','/assets/tractor.jfif',2);
INSERT INTO products(title,description,image,categoryid) VALUES('harvesters','harvester, in farming, any of several machines for harvesting; the design and function of harvesters varies widely according to crop. See binder; combine; corn harvester; cotton harvester; header; reaper; thresher; windrower. See also entries for particular crops (e.g., hay, for hay-cutting equipment).','/assets/harvestor.jfif',2);


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

-- catelfeed
INSERT INTO products(title,description,image,categoryid) VALUES('Sarki pend','Perfect mixture
Quality examined
Completely organic
Lower price
Free from damage by water','/assets/sarki pend.jpeg',5);

INSERT INTO products(title,description,image,categoryid) VALUES('Kandi','This useful to cow, Goat, buffawlo. This is one of the most important feed for animal','/assets/kandi.jpeg',5);

INSERT INTO products(title,description,image,categoryid) VALUES('Bhusa','This useful to cow, Goat, buffawlo. This is one of the most important feed for animal','/assets/bhusa.jpeg',5);
INSERT INTO products(title,description,image,categoryid) VALUES('bone meal','Bonemeal is a product created from the waste resulting from the slaughter of animals, especially beef cattle, by meat processors. It is a white powder made by grinding either raw or steamed animal bones','/image/bonemeal.jpg',5);


-- product details
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(1,120,1000,'1kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(1,240,1000,'2kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(2,300,1000,'10kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(2,550,1000,'25kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(3,2500,1000,'1kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(4,850990,1000,'42HP',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(4,1010150,1000,'52HP',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(4,550550,1000,'25HP',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(5,1200000,1000,'150HP',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(5,1500000,1000,'150HP',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(6,270,1000,'50kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(6,500,1000,'100kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(7,1200,1000,'50kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(7,600,1000,'25kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(8,1400,1000,'50kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(8,700,1000,'25kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(9,120,1000,'50ml',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(9,240,1000,'100ml',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(10,120,1000,'100ml',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(10,220,1000,'220ml',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(11,250,1000,'100gm',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(11,325,1000,'250kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(12,120,1000,'100gm',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(12,240,1000,'200gm',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(13,1050,1000,'25ml',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(13,1600,1000,'50ml',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(14,120,1000,'100gm',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(14,200,1000,'200gm',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(15,250,1000,'100gm',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(15,500,1000,'250gm',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(16,320,1000,'150ml',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(16,150,1000,'75ml',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(17,250,1000,'100ml',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(17,300,1000,'150ml',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(18,1700,1000,'50kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(18,700,1000,'25kg',2);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(19,1610,1000,'50kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(19,800,1000,'25kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(20,1400,1000,'50kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(20,700,1000,'25kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(21,500,1000,'50kg',1);
INSERT INTO productdetails(productid,unitprice,stockavailable,size,supplierid) VALUES(21,1000,1000,'100kg',1);
 
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

INSERT INTO orders(orderdate,shippeddate,customerid,total,status) VALUES ('2020-12-01 12:12:12','2020-12-02 10:12:12',2,120,'initiated');
INSERT INTO orders(orderdate,shippeddate,customerid,total,status) VALUES ('2020-12-01 12:12:12','2020-12-02 10:12:12',2,480,'cancelled');



-- ORDER_DETAILS DATA
INSERT INTO orderdetails(orderid,productdetailsid,quantity) VALUES (1,1,1);
INSERT INTO orderdetails(orderid,productdetailsid,quantity) VALUES (2,2,2);


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
INSERT INTO payments(date,mode,paymentstatus,transactionid,orderid) VALUES('2022-03-08 12:08:19','cash on delivery','paid',1,1);

INSERT INTO payments(date,mode,paymentstatus,transactionid,orderid) VALUES('2022-03-08 12:08:19','cash on delivery','paid',1,2);


SELECT * FROM payments;



-- FEEDBACKS DATA
INSERT INTO feedbacks(description,customerid) VALUES ('very good facilitities',2);
INSERT INTO feedbacks(description,customerid) VALUES ('good quality of products',3);

INSERT INTO questioncategories(category) VALUES('crop related questions');
INSERT INTO questioncategories(category) VALUES('soil related questions');
INSERT INTO questioncategories(category) VALUES('weather releted questions');


-- QUESTION TABLE DATA

INSERT INTO questions(description,categoryid) VALUES('How can I increase crop yield?',1);
INSERT INTO questions(description,categoryid) VALUES('How can I prevent crop damage from pests and diseases?',1);
INSERT INTO questions(description,categoryid) VALUES('How can I improve soil fertility? ',2);
INSERT INTO questions(description,categoryid) VALUES('How can I improve soil structure? ',2);
INSERT INTO questions(description,categoryid)VALUES('How can I prevent soil erosion? ',2);
INSERT INTO questions(description,categoryid) VALUES('What should I do if there is a drought?',3);
INSERT INTO questions(description,categoryid) VALUES('What should I do if there is heavy rainfall? ',3);
INSERT INTO questions(description,categoryid) VALUES('What should I do if there is extreme heat?',3);

-- CUSTOMERQUESTIONS TABLE DATA
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,1,'2022-01-15');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,2,'2023-02-15');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (2,4,'2023-01-15');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,3,'2022-05-15');
INSERT INTO customerquestions(customerid,questionid,questiondate) VALUES (3,2,'2022-08-15');

-- SME TABLE DATA
INSERT INTO subjectmatterexperts(expertise,userid) VALUES('crop related information',8);
INSERT INTO subjectmatterexperts(expertise,userid) VALUES('soil related information',9);



-- ANSWERS TABLE DATA

INSERT INTO answers(description,questionid) VALUES('Soil health: Ensure the soil is healthy by adding organic matter and nutrients, improving drainage and water retention, and avoiding soil erosion.',1);
INSERT INTO answers(description,questionid) VALUES('Monitor crops regularly for signs of pests and diseases and take appropriate measures to prevent and control them.
                                          Use resistant crop varieties.',1);
INSERT INTO answers(description,questionid)VALUES('Consider local weather patterns and the plants growth requirements.',2);
INSERT INTO answers(description,questionid) VALUES('Soil testing: Perform soil tests to determine nutrient deficiencies and pH levels.
                                           Fertilizer: Apply appropriate amounts of fertilizers to address nutrient deficiencies.',2);
INSERT INTO answers(description,questionid) VALUES('Reduce soil compaction: Avoid excessive tillage, limit heavy machinery use, and avoid working on wet soil.',2);
INSERT INTO answers(description,questionid) VALUES('Cover crops: Plant cover crops to help prevent soil erosion by reducing runoff and increasing soil structure.',3);
INSERT INTO answers(description,questionid) VALUES('Irrigation: Use irrigation techniques to provide plants with the necessary water.
                                          Crop selection: Choose crops that are drought-tolerant.',3);
INSERT INTO answers(description,questionid) VALUES('Soil erosion prevention: Implement soil erosion prevention practices, such as planting cover crops, to help protect soil from being washed away.
										  Crop selection: Choose crops that are better suited to wet conditions.',3);


-- SME ANSWERS
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (1,'2023-04-05 12:08:06',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (1,'2023-06-05 12:20:19',1);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (2,'2023-07-10 12:23:08',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (2,'2023-08-25 12:34:20',2);
INSERT INTO smeanswers(answerid,answerdate,smeid) VALUES (3,'2023-09-15 12:40:30',2);




