using EfcDataAccess.FileStorage;
using Grpc.Net.Client;
using GrpcClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;
using Grpc.Core;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfcDataAccess.DAOs;

public class ProductEfcDao : IProductDao
{
    
    private readonly ShopContext context;
    private readonly FileContext fileContext;

    private ICategoryDao categoryDao;
    
   // private readonly GrpcChannel Channel = GrpcChannel.ForAddress("http://localhost:8843");
    private ShopGrpc.ShopGrpcClient ClientProduct;
    public ProductEfcDao(ShopContext context, ICategoryDao categoryDao, FileContext fileContext)
    {
        this.context = context;
        var grpcChannel = new Channel("localhost:8843", ChannelCredentials.Insecure);
        ClientProduct = new(grpcChannel);
        this.categoryDao = categoryDao;
        this.fileContext = fileContext;
    }

    public async Task<string> Seed()
    {
        List<Product> products = context.Products.ToList();
        for (int i = 0; i < products.Count; i++)
        {
            Product? existing = products[i];
            if (existing == null)
            {
                throw new Exception($"Product with id {products[i].id} not found");
            }
            context.Products.Remove(existing);
            await context.SaveChangesAsync();    
        }
        await context.SaveChangesAsync();

        List<string> images = fileContext.Images.ToList();

        Product toCreate1 = new Product()
        {
            id = 1,
            name = "Stella Drop Earrings",
            description = "gold-filled, Cubic Zirconia, 30mm long, handmade",
            price = 10,
            stock = 25,
            image = images[0],
            ingredients = "gold",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate1);
        await context.SaveChangesAsync();
        Product toCreate2 = new Product()
        {
            id = 2,
            name = "Allium Blue Green Sapphire",
            description = "6.5 blue green sapphire, 5.5 mm, gold",
            price = 20,
            stock = 25,
            image = images[1],
            ingredients = "gold, blue green sapphire",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate2);
        await context.SaveChangesAsync();
        Product toCreate3 = new Product()
        {
            id = 3,
            name = "5.5 Beveled Edge Matte",
            description = "BE225-18KW 18K white gold, with rhodium finish",
            price = 25,
            stock = 25,
            image = images[2],
            ingredients = "gold, rhodium",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate3);
        await context.SaveChangesAsync();

        Product toCreate4 = new Product()
        {
            id = 4,
            name = "Dazzling Diamond Tennis Bracelet",
            description = "AU4002, AU4003, AU4004, AU4117, round diamonds, 10g, box clasp closure",
            price = 40,
            stock = 25,
            image = images[3],
            ingredients = "steel, diamond",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate4);
        await context.SaveChangesAsync();
        
        Product toCreate5 = new Product()
        {
            id = 5,
            name = "Diamond Letter Bracelet",
            description = "14K gold, 6-7 in, 6.5 mm letter size",
            price = 35,
            stock = 25,
            image = images[4],
            ingredients = "gold",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate5);
        await context.SaveChangesAsync();
        
        Product toCreate6 = new Product()
        {
            id = 6,
            name = "Endeavor",
            description = "BE2CF9335-14KR tantalum and 14K rose gold, 6.5 mm",
            price = 28,
            stock = 25,
            image = images[5],
            ingredients = "tantalum, rose gold",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate6);
        await context.SaveChangesAsync();
        
        Product toCreate7 = new Product()
        {
            id = 7,
            name = "Homme 8 in. Link Chain Bracelet",
            description = "BE55500-SLV silver, fold over clasp link chain",
            price = 15,
            stock = 25,
            image = images[6],
            ingredients = "silver",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate7);
        await context.SaveChangesAsync();
        
        Product toCreate8 = new Product()
        {
            id = 8,
            name = "Infinity Ring",
            description = "AU0269, 19x8x1.2 mm, 5.6g",
            price = 56,
            stock = 25,
            image = images[7],
            ingredients = "steel, diamond",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate8);
        await context.SaveChangesAsync();
        
        Product toCreate9 = new Product()
        {
            id = 9,
            name = "Large Pavé Diamond Round Necklace",
            description = "14Kgold, high-quality single cut diamonds, 16-18 in",
            price = 65,
            stock = 25,
            image = images[8],
            ingredients = "gold",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate9);
        await context.SaveChangesAsync();
        
        Product toCreate10 = new Product()
        {
            id = 10,
            name = "Pavé Diamond Huggie Hoops",
            description = "14K gold, high-quality single cut diamonds, 12x1.2 mm",
            price = 27,
            stock = 25,
            image = images[9],
            ingredients = "gold",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate10);
        await context.SaveChangesAsync();
        
        Product toCreate11 = new Product()
        {
            id = 11,
            name = "Pearl Aura Breaded Necklace",
            description = "AU2103(16.5 in), AU2106(18 in), 4 mm pearl, 14g",
            price = 73,
            stock = 25,
            image = images[10],
            ingredients = "silver, pearl",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate11);
        await context.SaveChangesAsync();
        
        Product toCreate12 = new Product()
        {
            id = 12,
            name = "Scorpio Zodiac Engravable Tag Pendant",
            description = "BE4509SC-SLV silver, 24 in.,  lobster clasp curb chain",
            price = 55,
            stock = 25,
            image = images[11],
            ingredients = "silver",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate12);
        await context.SaveChangesAsync();
        
        Product toCreate13 = new Product()
        {
            id = 13,
            name = "Vintage Emerald Cut Ring",
            description = "AU3010, 6x4mm Emerald Gemstone x1, 1.5mm White Topaz x 6, 1.4x20x1.5 mm, 1.7g",
            price = 29,
            stock = 25,
            image = images[12],
            ingredients = "steel, emerald gemstone, white topaz",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate13);
        await context.SaveChangesAsync();
        
        Product toCreate14 = new Product()
        {
            id = 14,
            name = "Wishbone Stacker Set",
            description = "14K gold, 1mm, pavé diamonds",
            price = 80,
            stock = 25,
            image = images[13],
            ingredients = "gold, diamond",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate14);
        await context.SaveChangesAsync();
        
        Product toCreate15 = new Product()
        {
            id = 15,
            name = "Zeke Curb Chain Necklace",
            description = "BE5CLC85-SLV silver, lobster clasp curb chain",
            price = 36,
            stock = 25,
            image = images[14],
            ingredients = "silver",
            category = categoryDao.GetByName("Jewelry").Result
        };
        await context.Products.AddAsync(toCreate15);
        await context.SaveChangesAsync();
        
        Product toCreate16 = new Product()
        {
            id = 16,
            name = "Mogor green T shirt",
            description = "The Mogor tee is as chilled as it gets. It comes with an old dye finish, to give it an authentic weathered look, which pairs well with our corduroy and flannel trousers or our sweatpants. It comes in an oversized fit and falls to the waist.",
            price = 49,
            stock = 25,
            image = images[15],
            ingredients = "100% organic cotton",
            category = categoryDao.GetByName("Clothes").Result
        };
        await context.Products.AddAsync(toCreate16);
        await context.SaveChangesAsync();
        
        Product toCreate17 = new Product()
        {
            id = 17,
            name = "Monothaki Black t shirt",
            description = "The Monothaki is set to be a staple in eco-friendly wardrobes everywhere. Its soft organic cotton, minimalist design and multiple colours help it slot into any outfit. It comes in a regular fit.",
            price = 46,
            stock = 25,
            image = images[16],
            ingredients = "100% organic cotton",
            category = categoryDao.GetByName("Clothes").Result
        };
        await context.Products.AddAsync(toCreate17);
        await context.SaveChangesAsync();
        
        Product toCreate18 = new Product()
        {
            id = 18,
            name = "Narotua sand t shirt",
            description = "Sprinkled with colourful neps, a men's rounded v-neckline t-shirt, with printed logo on the chest. Short sleeves, slightly dropped shoulders and rounded bottom hem makes a comfy choice.",
            price = 35,
            stock = 25,
            image = images[17],
            ingredients = "98% organic cotton and 2% recycled polyester",
            category = categoryDao.GetByName("Clothes").Result
        };
        await context.Products.AddAsync(toCreate18);
        await context.SaveChangesAsync();
        
        Product toCreate19 = new Product()
        {
            id = 19,
            name = "Cook- Golden Brown",
            description = "The Cook is as cosy as a shirt can be, thanks to its organic micro corduroy. It’s also remarkably soft, as well as carrying a chest pocket and “Twothirds” embroidery on the placket.",
            price = 45,
            stock = 25,
            image = images[18],
            ingredients = "Micro corduroy: 100% organic cotton",
            category = categoryDao.GetByName("Clothes").Result
        };
        await context.Products.AddAsync(toCreate19);
        await context.SaveChangesAsync();
        
        Product toCreate20 = new Product()
        {
            id = 20,
            name = "Killingq",
            description = "The Killingq features an impactful print, both front and back, which catches the eye any time of year. It’s also incredibly sustainable, due to being crafted from 50% recycled fabric.Designed in a regular fit, it falls to hip-length.",
            price = 74,
            stock = 25,
            image = images[19],
            ingredients = "50% recycled cotton and 50% organic cotton",
            category = categoryDao.GetByName("Clothes").Result
        };
        await context.Products.AddAsync(toCreate20);
        await context.SaveChangesAsync();
        
        Product toCreate21 = new Product()
        {
            id = 21,
            name = "The Tubou",
            description = "The Tubou makes for a nice change from the regular fit norm, its warm organic fabric and dropped shoulders giving a relaxed vibe that both surfers and non-surfers will love. This tee comes in an oversized fit.",
            price = 12,
            stock = 25,
            image = images[20],
            ingredients = "100% organic cotton",
            category = categoryDao.GetByName("Clothes").Result
        };
        await context.Products.AddAsync(toCreate21);
        await context.SaveChangesAsync();
        
        Product toCreate22 = new Product()
        {
            id = 22,
            name = "Razo",
            description = "For mild conditions, this classic jacket is elevated by a sherpa effect collar. With dropped shoulders, lightly padded sleeves, black sherpa lining and three snap button pockets. This jacket is a fairly oversized fit and is cut to fall slightly below the hips.",
            price = 45,
            stock = 25,
            image = images[21],
            ingredients = "100% organic cotton Lining, padding: 100% recycled polyester.",
            category = categoryDao.GetByName("Clothes").Result
        };
        await context.Products.AddAsync(toCreate22);
        await context.SaveChangesAsync();
        
        Product toCreate23 = new Product()
        {
            id = 23,
            name = "Vaqaba-Trouser",
            description = "Nothing can prepare you for how soft the Vaqava flannel trouser is. Its brushed finish is made even more appealing by rear welt pockets that are twinned with an embroidered wave motif.",
            price = 86,
            stock = 25,
            image = images[22],
            ingredients = "100% organic cotton",
            category = categoryDao.GetByName("Clothes").Result
        };
        await context.Products.AddAsync(toCreate23);
        await context.SaveChangesAsync();
        
        Product toCreate24 = new Product()
        {
            id = 24,
            name = "Balavu",
            description = "Trust us, cords are about to be everywhere. Why not treat yourself to ones that are both organic and stylish? A simple, sleek design is complemented by two wave embroidered rear pockets.",
            price = 23,
            stock = 25,
            image = images[23],
            ingredients = "Micro corduroy: 100% organic cotton",
            category = categoryDao.GetByName("Clothes").Result
        };
        await context.Products.AddAsync(toCreate24);
        await context.SaveChangesAsync();
        
        Product toCreate25 = new Product()
        {
            id = 25,
            name = "Tuvalu",
            description = "Classic chinos, the fair fashion way. A rubber back waistband, snap fastener and adjustable internal drawstring added for extra comfort. Four pockets in total, one with embroidery detail.",
            price = 43,
            stock = 25,
            image = images[24],
            ingredients = "100% organic cotton",
            category = categoryDao.GetByName("Clothes").Result
        };
        await context.Products.AddAsync(toCreate25);
        await context.SaveChangesAsync();
        
        Product toCreate26 = new Product()
        {
            id = 26,
            name = "Chios",
            description = "Sustainable chinos. 4 patch pockets - with wave embroidery on one of the back ones. A snap fastener, belt loops and a rubber back waistband adds functionality and comfort. Regular fit straight cut trousers, cut at ankle length.",
            price = 64,
            stock = 25,
            image = images[25],
            ingredients = "100% organic cotton flannel",
            category = categoryDao.GetByName("Clothes").Result
        };
        await context.Products.AddAsync(toCreate26);
        await context.SaveChangesAsync();
        
        Product toCreate27 = new Product()
        {
            id = 27,
            name = "Grotta",
            description = "We bring you the Grótta sweatshirt, in an attractive shade of green. A plain and simple garment that prioritises comfort and reduced impact. Designed with a drawstring hood, ribbed edges and our logo embroidered on the chest. The hoodie comes in a regular fit and hip-length cut. We all have those days when throwing on a comfy and cosy jumper just makes sense, which is why we love to have the Grótta in our wardrobe. Paired with a long coat or bomber jacket, you have the finest casual fit - you can also give it a nice twist with an oversized t-shirt on top!",
            price = 57,
            stock = 25,
            image = images[26],
            ingredients = "100% organic cotton",
            category = categoryDao.GetByName("Clothes").Result
        };
        await context.Products.AddAsync(toCreate27);
        await context.SaveChangesAsync();
        
        Product toCreate28 = new Product()
        {
            id = 28,
            name = "Auriol",
            description = "Hoodies can comfort and warm you whether you’re at home under a blanket or out braving the elements. The Auriol is soft as snow and comes with a drawstring hood, logo, and ribbed edges.",
            price = 87,
            stock = 25,
            image = images[27],
            ingredients = "100% organic cotton",
            category = categoryDao.GetByName("Clothes").Result
        };
        await context.Products.AddAsync(toCreate28);
        await context.SaveChangesAsync();
        
        Product toCreate29 = new Product()
        {
            id = 29,
            name = "Corn",
            description = "A knit hoodie that combines the warmth and durability of wool with the refined feel of recycled plastic fabrics, the corn is a cut above. It has a drawstring hood and cosy pouch. It comes in a regular fit and has ribbed edges.",
            price = 64,
            stock = 25,
            image = images[28],
            ingredients = "All recycled materials: 50% polyester, 35% wool, 15% polyamide",
            category = categoryDao.GetByName("Clothes").Result
        };
        await context.Products.AddAsync(toCreate29);
        await context.SaveChangesAsync();
        
        Product toCreate30 = new Product()
        {
            id = 30,
            name = "Ekins",
            description = "A double-breasted corduroy coat with vintage appeal. Includes foldable cuffs, lightly padded sleeves and corozo buttons plus two external pockets. Best suited for mild cold climates. This casual women’s jacket is an oversized fit which falls to the thigh.",
            price = 43,
            stock = 25,
            image = images[29],
            ingredients = "All recycled materials: 50% polyester, 35% wool, 15% polyamide",
            category = categoryDao.GetByName("Clothes").Result
        };
        await context.Products.AddAsync(toCreate30);
        await context.SaveChangesAsync();
        
        Product toCreate31 = new Product()
        {
            id = 31,
            name = "Forest Floor Wallpaper Mural",
            description = "Misty light filtering through woodland gives off a calming aesthetic and will always be a good choice when looking for a wallpaper that invites a relaxing atmosphere into the space. A perfect choice for a range of spaces but especially well suited to living rooms and bedrooms.*Fire Ratings: European standard en 13501 1 b-s1 d0 & US Standard ASTM e84 fire rating: Class A*Install Method: Paste the wall, butt joined*Paper Type: non-woven 175 gsm, velvet matte finish. *Environmental Credentials: PVC-free paper, printed with non-toxic inks and 100% recyclable packaging*100% plastic-free packaging that's fully recyclable",
            price = 26,
            stock = 25,
            image = images[30],
            ingredients = "Ethically-sourced PVC-free paper and water-based, non-toxic inks",
            category = categoryDao.GetByName("Home Decor").Result
        };
        await context.Products.AddAsync(toCreate31);
        await context.SaveChangesAsync();
        
        Product toCreate32 = new Product()
        {
            id = 32,
            name = "Braid Nook",
            description = "Plaited from a plush wool blend, this petite version of our round Braid rug easily slots into odd-shaped, curved or tight spaces. Assured to age beautifully, its lovely contours restore a sense of calm and comfort into the home.",
            price = 455,
            stock = 25,
            image = images[31],
            ingredients = "78% Wool & 17% Viscose blend, 5% Jute / 100% Cotton Backing  Fiber: Wool viscose blend Construction: Hand braided, coiled, stitched",
            category = categoryDao.GetByName("Home Decor").Result
        };
        await context.Products.AddAsync(toCreate32);
        await context.SaveChangesAsync();
        
        Product toCreate33 = new Product()
        {
            id = 33,
            name = "Reusable Fabric Gift Wrap Christmas Reindeers",
            description = "These reusable Christmas fabric gift wraps are the ideal zero-waste alternative to wrapping paper. They are made in Britain using organic cotton and can be used over and over again, passed around family and friends and can even be thrown in the washing machine if needed.This reusable gift wrapping is printed on organic medium weight cotton and has two cotton braids attached to the corners for easy wrapping. A wrapping guide is included with each wrap along as well as a recycled card gift tag for the complete reusable Christmas gift wrapping pack.",
            price = 13,
            stock = 25,
            image = images[32],
            ingredients = "100% organic cotton fabric, cotton cord and recycled card gift tag, - Recycled Paper Wrap Guide",
            category = categoryDao.GetByName("Home Decor").Result
        };
        await context.Products.AddAsync(toCreate33);
        await context.SaveChangesAsync();
        
        Product toCreate34 = new Product()
        {
            id = 34,
            name = "Bamboo Fibre Lunchbox - Pink Coral",
            description = "Bamboo fibre lunchbox with pink coral design with a food grade silicone seal to keep your food fresh and bamboo lid which can be used as a place to put your sandwiches. This environmentally-friendly pack lunchbox is made with sustainable bamboo fibre, corn starch and melamine resin. Comes in a blue wave gift box perfect for presents, making it a great eco gift idea. Capacity - 700ml. Care instructions - Dishwasher safe, non microwavable.It is not recommended to store liquid in this lunchbox as the wooden lid could swell up. Country of Manufacture - China. ",
            price = 22,
            stock = 25,
            image = images[33],
            ingredients = "50% bamboo, 25% corn starch, 25% melamine resin. Product Packaging - Cardboard.",
            category = categoryDao.GetByName("Home Decor").Result
        };
        await context.Products.AddAsync(toCreate34);
        await context.SaveChangesAsync();
        
        Product toCreate35 = new Product()
        {
            id = 35,
            name = "Whale Bud Vase Air Plant Holder",
            description = "A handmade ceramic whale, perfect to use as a bud vase or an air plant holder. These little whales are a cheerful piece of home decor with their quirky features and nod to ocean life. Each whale is handcrafted, making every one completely unique. All are glazed inside making them water tight. Length: 10cm, Height: 5.2cm, Width: 6cm, Hole Diameter: 2.5cm. *Approximate Dimensions.",
            price = 40,
            stock = 25,
            image = images[34],
            ingredients = "Stoneware clay. Product Packaging - eco friendly packaging.",
            category = categoryDao.GetByName("Home Decor").Result
        };
        await context.Products.AddAsync(toCreate35);
        await context.SaveChangesAsync();
        
        Product toCreate36 = new Product()
        {
            id = 36,
            name = "Wildlife Collection Organic Cotton Socks",
            description = "These statement socks are inspired by Scottish roots.Ethically made in Portugal with organic cotton, our original design brings freshness and character to a boring sock drawer.",
            price = 14,
            stock = 25,
            image = images[35],
            ingredients = "78% certified organic cotton, 20% polyamide, 2% elastane",
            category = categoryDao.GetByName("Home Decor").Result
        };
        await context.Products.AddAsync(toCreate36);
        await context.SaveChangesAsync();
        
        Product toCreate37 = new Product()
        {
            id = 37,
            name = "Birdcage Side Table",
            description = "As a simple side table or a quirky plant stand, this 'birdcage' table is sure to make a statement. The top is made from used coffee bean husk, a byproduct of the coffee roasting industry. The edges have been wrapped in recycled handmade paper, and the legs are made using either recycled birch ply (whenever available) or always FSC certified.Table top diametre: 40cmHeight with legs: 70cm",
            price = 375,
            stock = 25,
            image = images[36],
            ingredients = "Recycled Coffee Chaff, 100% Recycled or FSC Certified Birch Ply, Recycled Paper, Non-Toxic Resin, Water-Based and Low VOC Paint, Water-Based Lacquer, Non-Toxic Natural Dye.",
            category = categoryDao.GetByName("Home Decor").Result
        };
        await context.Products.AddAsync(toCreate37);
        await context.SaveChangesAsync();
        
        Product toCreate38 = new Product()
        {
            id = 38,
            name = "Bamboo Fibre Plate - Dugong",
            description = "These reusable bamboo plates are made with environmentally-friendly bamboo fibre, corn starch and resin, suitable for indoor and outdoor use. Great for parties and picnics, they are dishwasher safe and BPA Free. Available in a set of 4. Size - 22.5cm.",
            price = 9,
            stock = 25,
            image = images[37],
            ingredients = "Each item - 50% bamboo fibre, 25% corn starch, 25% melamine binding resin. Product Packaging - Cardboard. ",
            category = categoryDao.GetByName("Home Decor").Result
        };
        await context.Products.AddAsync(toCreate38);
        await context.SaveChangesAsync();
        
        Product toCreate39 = new Product()
        {
            id = 39,
            name = "RESPIIN MINI JUTE BOWL SET - FIRE",
            description = "A set of three sustainable jute storage nesting bowls in bright red and orange tones made with azo-free dyes. Made from biodegradable and eco-friendly jute, the bowls have a rustic feel with a bright contemporary look, perfect for any environmentally conscious household. Large – H6.5 x Dia.16cm Medium – H6 x Dia.13.5cm Small – H5.5 x Dia.11cm Handmade in Bangladesh",
            price = 13,
            stock = 25,
            image = images[38],
            ingredients = "100% ecological and bio-degradable jute",
            category = categoryDao.GetByName("Home Decor").Result
        };
        await context.Products.AddAsync(toCreate39);
        await context.SaveChangesAsync();
        
        Product toCreate40 = new Product()
        {
            id = 40,
            name = "Recycled Coconut Bowls & Spoons Gift Set",
            description = "Clean U's organic and sustainable Coconut Bowls and Spoons gift set, handmade using reclaimed coconuts that would otherwise be burned after harvest. These sustainable bowls are etched by local craftsmen in the Ben Tre region of Vietnam, each bowl is handpicked from the thickest and highest quality coconuts. Available as a set containing - 1x Coconut Bowl & Spoon or 2X Coconut Bowls and 2X Coconut Spoons. Care & Usage - Not dishwasher safe. The coconut bowl is not suitable for hot contents due to the natural material. Size - Approximately W14cm x H7cm.",
            price = 20,
            stock = 25,
            image = images[39],
            ingredients = "100% recycled coconut shells and coconut wood. Product packaging - 100% biodegradable, cardboard box with recycled shredded, coffee cup filler and jute string",
            category = categoryDao.GetByName("Home Decor").Result
        };
        await context.Products.AddAsync(toCreate40);
        await context.SaveChangesAsync();
        
        Product toCreate41 = new Product()
        {
            id = 41,
            name = "Himalayan Salt Candle Holder",
            description = "Harness the benefits of a salt lamp with this 100% natural Himalayan salt tea light holder. Provides a warm glow from the candle when lit, creating a lovely relaxing atmosphere. Variation in colour and shape due to the natural beauty of the salt. Dimensions (approximately): 9cm Wide, 9cm High.",
            price = 13,
            stock = 25,
            image = images[40],
            ingredients = "100% Himalayan Salt. Country of Manufacture - Pakistan. Product Packaging - Recyclable cardboard packaging.",
            category = categoryDao.GetByName("Home Decor").Result
        };
        await context.Products.AddAsync(toCreate41);
        await context.SaveChangesAsync();
        
        Product toCreate42 = new Product()
        {
            id = 42,
            name = "Ceramic Tumbler",
            description = "A unique handmade ceramic tumbler for hot and cold drinks from tea and coffee to water, juice and wine. Crafted by hand, each ceramic cup is hand-thrown of fine stoneware clay and coated with ZAN+ME's own food-safe glazes. The unglazed outer surface enhances the cup’s tactile charm. Care - dishwasher safe, but hand-washing recommended - do not microwave. Size - 9.5cm tall x 7.5cm wide. Holds - 200ml. ",
            price = 19,
            stock = 25,
            image = images[41],
            ingredients = "High-fired stoneware clay sourced in the UK, in-house glazes. Product Packaging - Recycled paper and cardboard. ",
            category = categoryDao.GetByName("Home Decor").Result
        };
        await context.Products.AddAsync(toCreate42);
        await context.SaveChangesAsync();
        
        Product toCreate43 = new Product()
        {
            id = 43,
            name = "Breathable Linen Bread Bag",
            description = "This wonderful breathable linen bread bag, featuring a hand printed designs, is ideal for storing loaves, rolls, delicious artisan breads and patisserie. Handmade in Cornwall using natural linen with a cotton tie. Measures approx 42cm x 18cm x 12cm. Care instructions - Machine washable at 30 degrees.",
            price = 24,
            stock = 25,
            image = images[42],
            ingredients = "Linen & Cotton. Product Packaging - Paper, Postage Packaging - Brown paper and tissue paper - fully compostable.",
            category = categoryDao.GetByName("Home Decor").Result
        };
        await context.Products.AddAsync(toCreate43);
        await context.SaveChangesAsync();
        
        Product toCreate44 = new Product()
        {
            id = 44,
            name = "Recycled Cotton Omar Seat Pad",
            description = "Bring an exotic feel to any indoor or outdoor space with these sustainable seat pads which has been hand crafted with recycled cotton and hand printed using traditional methods from India. These intricately patterned seat pads are filled with 100% recycled polyester fibers and are inspired by the mystery of Moroccan windows making them an ideal choice to add a touch of eco-friendly elegance and comfort to any home or garden arrangement. Dimensions - 43 x 43cm.",
            price = 20,
            stock = 25,
            image = images[43],
            ingredients = "100% recycled cotton and recycled polyester filling. Product Packaging - Biodegradable cover with Jute and recycled paper tag",
            category = categoryDao.GetByName("Home Decor").Result
        };
        await context.Products.AddAsync(toCreate44);
        await context.SaveChangesAsync();
        
        Product toCreate45 = new Product()
        {
            id = 45,
            name = "Ocean Bottle - Forest Green",
            description = "This gorgeous forest green reusable water bottle reflects the colours of nature whilst also protecting it. Made with recycled, double-walled vacuum-insulated stainless steel keeping cold drinks cold, and hot drinks hot. This award-winning Ocean Bottle has an anti-leak dual opening lid, either drink from the bottle or use the lid as a handy drinking cup! Size - 500ml.",
            price = 40,
            stock = 25,
            image = images[44],
            ingredients = "Stainless steel, BPA-free plastic, silicone rubber and ocean-bound plastic. All materials are fully recyclable. Product Packaging - 100% Recycled and recyclable cardboard box. Plastic free packaging.",
            category = categoryDao.GetByName("Home Decor").Result
        };
        await context.Products.AddAsync(toCreate45);
        await context.SaveChangesAsync();
        
        Product toCreate46 = new Product()
        {
            id = 46,
            name = "Expressionist Pro Mascara",
            description = "Long-wear, defining and lengthening mascara",
            price = 20,
            stock = 25,
            image = images[45],
            ingredients = "Expressionist Pro Mascara Net Wt. - 0.26 oz. (7.6g). Ingredients: aqua (water), cera alba/cera alba (beeswax), c10-18 triglycerides, stearic acid, copernicia cerifera cera / copernicia cerifera (carnauba) wax, castor isostearate beeswax succinate, glyceryl stearate, glyceryl caprylate, glycerin, propanediol, glyceryl undecylenate, potassium sorbate, sodium hydroxide, xanthan gum, cellulose, tocopherol, helianthus annuus seed oil/ helianthus annuus (sunflower) seed oil. May Contain titanium dioxide (ci 77891), iron oxides (ci 77491, ci 77499).",
            category = categoryDao.GetByName("Cosmetics").Result
        };
        await context.Products.AddAsync(toCreate46);
        await context.SaveChangesAsync();
        
        Product toCreate47 = new Product()
        {
            id = 47,
            name = "Supernatural Stick Multi-Use Blush",
            description = "Creamy, hydrating blush stick for a pop of color",
            price = 22,
            stock = 25,
            image = images[46],
            ingredients = "Supernatural Stick Multi-Use Blush Net Wt. 0.15 oz. (4.5 g) Ingredients: helianthus annuus (sunflower) seed oil/helianthus annuus seed oil, ricinus communis (castor) seed oil/ricinus communis seed oil, mica, carthamus tinctorius (safflower) seed oil/carthamus tinctorius seed oil, copernicia cerifera (carnauba) wax/copernicia cerifera cera, synthetic beeswax, castor isostearate succinate, tocopherol, polyhydroxystearic acid, caprylic/capric triglyceride, simmondsia chinensis (jojoba) seed oil/simmondsia chinensis seed oil, rosa rubiginosa seed oil, crambe abyssinica seed oil, isostearic acid, tin oxide, calendula officinalis flower extract, lecithin, polyglyceryl-3 polyricinoleate, camellia sinensis(green tea)seed oil/camellia sinensis seed oil, aloe barbadensis leaf juice, maltodextrin, potassium sorbate, sodium benzoate. May Contain titanium dioxide (ci 77891), iron oxides(ci 77491, ci 77492), red 6 lake (ci 15850), red 7 lake (ci 15850).",
            category = categoryDao.GetByName("Cosmetics").Result
        };
        await context.Products.AddAsync(toCreate47);
        await context.SaveChangesAsync();
        
        Product toCreate48 = new Product()
        {
            id = 48,
            name = "Bio Stick Foundation",
            description = "Creamy, multi-use hydrating foundation stick",
            price = 27,
            stock = 25,
            image = images[47],
            ingredients = "Bio Stick Foundation Net Wt. - 0.35 oz. (10g) Ingredients: helianthus annuus seed oil/helianthus annuus (sunflower) seed oil, ricinus communis seed oil/ricinus communis(castor) seed oil, carthamus tinctorius seed oil/carthamus tinctorius (safflower) seed oil, copernicia cerifera cera/copernicia cerifera (carnauba) wax, synthetic beeswax, castor isostearate succinate, mica, tocopherol, polyhydroxystearic acid, caprylic/caprictriglyceride, simmondsia chinensisseed oil/simmondsia chinensis(jojoba) seed oil, rosa rubiginosa seed oil, crambe abyssinica seed oil, isostearic acid, lecithin, polyglyceryl-3 polyricinoleate, calendula officinalis flower extract, camellia sinensis seed oil/camellia sinensis (green tea) seed oil, aloe barbadensis leaf juice, maltodextrin, sodium benzoate, potassium sorbate. May Contain titanium dioxide (ci 77891), iron oxides (ci 77491,ci 77492,ci 77499).",
            category = categoryDao.GetByName("Cosmetics").Result
        };
        await context.Products.AddAsync(toCreate48);
        await context.SaveChangesAsync();
        
        Product toCreate49 = new Product()
        {
            id = 49,
            name = "Optimist Lipstick",
            description = "Hydrating, high-pigment lipstick for long-lasting color",
            price = 16,
            stock = 25,
            image = images[48],
            ingredients = "Optimist Lipstick Net Wt. 0.12 oz. (3.5 g) Ingredients: ricinus communis seed oil/ricinus communis (castor) seed oil, jojoba esters, isostearyl isostearate, ethylhexyl palmitate, oleyl alcohol, bis-diglyceryl polyacyladipate-2, copernicia cerifera cera/copernicia cerifera (carnauba) wax, candelilla cera/euphorbia cerifera (candelilla) wax, polyglyceryl-2 triisostearate, synthetic beeswax, helianthus annuus seed wax/helianthus annuus(sunflower) seed wax, mica, tocopherol, theobroma grandiflorum seed butter, carthamus tinctoriusseed oil/carthamus tinctorius(safflower) seed oil, helianthus annus seed oil/helianthus annuus (sunflower) seed oil, acacia decurrens flower wax, polyglycerin-3, aloe barbadensis leaf juice, maltodextrin, potassium sorbate, sodium benzoate. May Contain titanium dioxide (ci 77891), iron oxides (ci 77491,ci 77492,ci 77499), red 40 lake (ci 16035), red 6 lake (ci 15850), red 7 lake (ci 15850), blue 1 lake (ci 42090), yellow 6 lake (ci 15985).",
            category = categoryDao.GetByName("Cosmetics").Result
        };
        await context.Products.AddAsync(toCreate49);
        await context.SaveChangesAsync();
        
        Product toCreate50 = new Product()
        {
            id = 50,
            name = "Power Palette Eyeshadow",
            description = "Long-wear neutral powder eyeshadow palettes",
            price = 22,
            stock = 25,
            image = images[49],
            ingredients = "Power Palette Eyeshadow Net Wt. 0.26 oz. (7.5 g) Ingredients: mica, simmondsia chinensis seed oil/simmondsia chinensis(jojoba) seed oil, synthetic fluorphlogopite, calcium aluminum borosilicate, silica, copernicia cerifera cera/copernicia cerifera (carnauba) wax, boron nitride, sodium dehydroacetate, lauroyl lysine, vitis vinifera seed oil/vitis vinifera(grape) seed oil, tocopherol, ricinus communis seed oil/ricinus communis (castor) seed oil, olea europaea fruit oil/olea europaea(olive) fruit oil, tin oxide. May Contain iron oxides (ci 77491, ci 77499), ferric ferrocyanide (ci 77510), titanium dioxide (ci 77891), bronze powder (ci 77400), yellow 5 lake (ci 19140), red 40 lake (ci 16035), manganese violet (ci 77742), blue 1 lake (ci 42090).",
            category = categoryDao.GetByName("Cosmetics").Result
        };
        await context.Products.AddAsync(toCreate50);
        await context.SaveChangesAsync();
        
        Product toCreate51 = new Product()
        {
            id = 51,
            name = "Evercalm™ Ultra Comforting Rescue Mask",
            description = "Fast-acting calming and intensively hydrating face mask.",
            price = 50,
            stock = 25,
            image = images[50],
            ingredients = "aqua (water),glycerin,cetearyl alcohol,caprylyl caprylate/caprate,olus oil,lactobacillus ferment,butyrospermum,parkii (shea) butter,helianthus annus (sunflower) seed wax,simmondsia chinesis (jojoba) seed oil,cetearyl glucoside,propanediol,algae extract,cetyl alcohol,lactobacillus,alpha-glucan oligosaccharide,parfum (fragrance),tocopheryl acetate,caprylic/capric triglyceride,panthenol,carbomer,vaccinium vitas-idaea (lingonberry) seed oil,xanthan gum,arnica montana flower extract,camelina sativa seed oil,cocus nucifera (coconut) fruit extract,tocopherol,magnesium carboxymethyl beta-glucan,malachite extract,albatrellus ovinus extract,laminaria ochroleuca extract,glucose,phenoxyethanol,helianthus annuus (sunflower) seed oil,citric acid,sodium hydroxide,rosmarinus officinalis leat extract,citronellol,geraniol,limonene,linalool",
            category = categoryDao.GetByName("Cosmetics").Result
        };
        await context.Products.AddAsync(toCreate51);
        await context.SaveChangesAsync();
        
        Product toCreate52 = new Product()
        {
            id = 52,
            name = "Evercalm™ Global Protection Day Cream",
            description = "Future-proofing day cream to immediately calm and soothe sensitive skin.",
            price = 50,
            stock = 25,
            image = images[51],
            ingredients = "aqua (water),cetearyl alcohol,camellia oleifera seed oil,cetearyl ethylhexanoate,myristyl myristate,sesamum indicum (sesame) seed oil,glycerin,butyrospermum parkii (shea) butter,caprylic/capric triglyceride,triheptanoin,cetearyl glucoside,myristyl laurate,oryzanol,helianthus annuus (sunflower) seed oil,ethylhexylglycerin,vaccinium macrocarpon (cranberry) seed oil,bisabolol,ribes nigrum (black currant) seed oil,carbomer,hippophae rhamnoides fruit extract,citrus nobilis (mandarin orange) peel oil,tocopherol,anthemis nobilis flower oil,cinnamomum camphora linalloliferum (ho wood) leaf oil,pelargonium graveolens flower oil,phenoxyethanol,sodium dehydroacetate,pueraria lobata (kudzu) symbiosome extract,laminaria ochroleuca extract,cassia alata leaf extract,calendula officinalis flower extract,glucose,parfum (fragrance),rosmarinus officinalis (rosemary) leaf extract,lactic acid,sodium hydroxide,citronellol,geraniol,limonene,linalool",
            category = categoryDao.GetByName("Cosmetics").Result
        };
        await context.Products.AddAsync(toCreate52);
        await context.SaveChangesAsync();
        
        Product toCreate53 = new Product()
        {
            id = 53,
            name = "Evercalm™ Gentle Cleansing Gel",
            description = "Non-drying cleanser for stressed & sensitive skin.",
            price = 37,
            stock = 25,
            image = images[52],
            ingredients = "aqua (water),glycerin,coco-glucoside,polysorbate 20,xanthan gum,panthenol,sodium lauroyl oat amino acids,inulin,citrus aurantium amara (bitter orange) flower water extract,alpha-glucan oligosaccharide,sodium carboxymethyl betaglucan,phenoxyethanol,sodium benzoate,parfum (fragrance),lactic acid,linalool",
            category = categoryDao.GetByName("Cosmetics").Result
        };
        await context.Products.AddAsync(toCreate53);
        await context.SaveChangesAsync();
        
        Product toCreate54 = new Product()
        {
            id = 54,
            name = "Keep Young And Beautiful™ Instant Firming Beauty Shot",
            description = "Anti-aging gel serum to instantly plump and lift.",
            price = 62,
            stock = 25,
            image = images[53],
            ingredients = "Aqua (Water), Sodium Hyaluronate, Hydroxypropyl Methylcellulose, Hydroxyacetophenone, Pullulan, Carbomer, Porphyridium Cruentum Extract, Rosa Damascena Flower Oil, Phenoxyethanol, Rosa Damascena Extract, Sodium Hydroxide, Citronellol, Geraniol",
            category = categoryDao.GetByName("Cosmetics").Result
        };
        await context.Products.AddAsync(toCreate54);
        await context.SaveChangesAsync();
        
        Product toCreate55 = new Product()
        {
            id = 55,
            name = "Clean Screen Mineral SPF 30 Mattifying Face Sunscreen",
            description = "Silicone-free, 22% zinc oxide SPF.",
            price = 40,
            stock = 25,
            image = images[54],
            ingredients = "aqua (water),zinc oxide,caprylic/capric triglyceride,aloe barbadensis leaf juice,glycerin,caprylyl caprylate/caprate,propanediol,arachidyl alcohol,cetearyl alcohol,coco-glucoside,oryza sativa starch,pongamia glabra seed oil,microcrystalline cellulose,behenyl alcohol,phenoxyethanol,arachidyl glucoside,isostearic acid,lecithin,polyglyceryl-3 polyricinoleate,polyhydroxystearic acid,passiflora edulis fruit extract,ethylhexylglycerin,glyceryl oleate,vaccinium macrocarpon (cranberry) seed oil,xanthan gum,cellulose gum,sodium chloride,hippophae rhamnoides oil,citrus nobilis (mandarin orange) peel oil,anthemis nobilis flower oil,cinnamomum camphora linalloliferum (ho wood) leaf oil,pelargonium graveolens flower oil,glucose,parfum (fragrance),helianthus annuus (sunflower) seed oil,tocopherol,rosmarinus officinalis (rosmary) leaf extract,hydrogenated palm glycerides citrate,citric acid,sodium hydroxide,citronellol,geraniol,limonene,linalool",
            category = categoryDao.GetByName("Cosmetics").Result
        };
        await context.Products.AddAsync(toCreate55);
        await context.SaveChangesAsync();
        
        Product toCreate56 = new Product()
        {
            id = 56,
            name = "rosemary mint hand and body wash",
            description = "Gentle cleansing formula. Awakens the senses with an invigorating aroma of certified organic rosemary and peppermint with other pure flower and plant essences.",
            price = 26,
            stock = 25,
            image = images[55],
            ingredients = "Ingredients: Water Aqua, Ammonium Lauryl Sulfate, Propanediol, Decyl Glucoside, Sodium Hydroxypropylsulfonate Laurylglucoside Crosspolymer, Babassuamidopropyl Betaine, Sodium Chloride, Aloe Barbadensis Leaf, Rosmarinus Officinalis (Rosemary) Leaf Oil, Mentha Piperita (Peppermint) Oil, Lavandula Angustifolia (Lavender) Oil, Origanum Majorana Leaf Oil, Menthol, Alpha-Glucan Oligosaccharide, Glycerin, Tocopherol, Glycine Soja (Soybean) Oil, Glycol Distearate, Acrylates Copolymer, Citric Acid, Sodium Hydroxide, Fragrance (Parfum), Linalool, Limonene, Isoeugenol, Sodium Phytate, Phenoxyethanol, Sodium Benzoate, Potassium Sorbate <ILN43582> Please be aware that ingredient lists may change or vary from time to time. Please refer to the ingredient list on the product package you receive for the most up to date list of ingredients.",
            category = categoryDao.GetByName("Cosmetics").Result
        };
        await context.Products.AddAsync(toCreate56);
        await context.SaveChangesAsync();
        
        Product toCreate57 = new Product()
        {
            id = 57,
            name = "rosemary mint body lotion",
            description = "A lightweight lotion with certified organic peppermint cools and revitalizes skin. Awakens the senses with an invigorating aroma of certified organic rosemary and peppermint with other pure flower and plant essences.",
            price = 32.5,
            stock = 25,
            image = images[56],
            ingredients = "Ingredients: Water Aqua, Coco-Caprylate/Caprate, Caprylic/Capric Triglyceride, Polyglyceryl-10 Oleate, Glyceryl Stearate, Cetyl Alcohol, Hydroxypropyl Starch Phosphate, Glycerin, Aloe Barbadensis Leaf, Alpha-Glucan Oligosaccharide, Tocopherol, Helianthus Annuus (Sunflower) Seed Oil, Sodium Pca, Capryloyl Glycine, Xanthan Gum, Menthol, Dimethicone, Peg-100 Stearate, Fragrance (Parfum), Limonene, Linalool, Isoeugenol, Sodium Gluconate, Phenoxyethanol, Sodium Benzoate <ILN43960> Please be aware that ingredient lists may change or vary from time to time. Please refer to the ingredient list on the product package you receive for the most up to date list of ingredients.",
            category = categoryDao.GetByName("Cosmetics").Result
        };
        await context.Products.AddAsync(toCreate57);
        await context.SaveChangesAsync();
        
        Product toCreate58 = new Product()
        {
            id = 58,
            name = "lip saver™",
            description = "Nurture your lips with our soothing, moisturizing, balm containing naturally derived waxes. Delivers moisture relief to dry lips. refreshes with cinnamon leaf, clove and anise oils",
            price = 16.5,
            stock = 25,
            image = images[57],
            ingredients = "Ingredients: Ricinus Communis (Castor) Seed Oil, Jojoba Esters, Helianthus Annuus (Sunflower) Seed Oil, Butyrospermum Parkii (Shea Butter), Euphorbia Cerifera (Candelilla) Wax Candelilla CeraCire De Candelilla, Copernicia Cerifera (Carnauba) Wax Copernicia Cerifera Cera Cire De Carnauba, Helianthus Annuus (Sunflower) Seed Wax, Hydrogenated Castor Oil, Tocopherol, Flavor (Aroma), Coumarin, Geraniol, Eugenol, Cinnamal, Citronellol, Linalool, Limonene, Benzyl Benzoate <ILN45755> Please be aware that ingredient lists may change or vary from time to time. Please refer to the ingredient list on the product package you receive for the most up to date list of ingredients.",
            category = categoryDao.GetByName("Cosmetics").Result
        };
        await context.Products.AddAsync(toCreate58);
        await context.SaveChangesAsync();
        
        Product toCreate59 = new Product()
        {
            id = 59,
            name = "aveda men pure-formance™ aroma spray",
            description = "A rich, spicy, refreshing aroma comprised of kunzea, citrus and certified organic essential oils of spearmint, vetiver and lavender.",
            price = 52,
            stock = 25,
            image = images[58],
            ingredients = "Ingredients: Alcohol Denat., Cetearyl Isononanoate, Fragrance (Parfum), Limonene, Farnesol, Eugenol, Linalool, Citronellol, Benzyl Alcohol, Citral, Benzyl Benzoate, Coumarin, Geraniol, Isoeugenol, Tocopherol <ILN40786> Please be aware that ingredient lists may change or vary from time to time. Please refer to the ingredient list on the product package you receive for the most up to date list of ingredients.",
            category = categoryDao.GetByName("Cosmetics").Result
        };
        await context.Products.AddAsync(toCreate59);
        await context.SaveChangesAsync();
        
        Product toCreate60 = new Product()
        {
            id = 60,
            name = "botanical repair™ strengthening shampoo",
            description = "Luxuriously cleanses while helping strengthen and repair damaged hair with the power of plants*. Gently removes excess sebum, product build-up and pollution.",
            price = 36,
            stock = 25,
            image = images[59],
            ingredients = "Ingredients: Water Aqua, Sodium Cocoyl Isethionate, Sodium Methyl Cocoyl Taurate, Sodium Lauryl Sulfoacetate, Propanediol, Babassuamidopropyl Betaine, Sodium Hydroxypropylsulfonate Laurylglucoside Crosspolymer, Sodium Chloride, Persea Gratissima (Avocado) Oil, Plukenetia Volubilis (Sacha Inchi) Seed Oil, Camellia Oleifera (Green Tea) Seed Oil, Octyldodecyl Citrate Crosspolymer, Hydroxypropylgluconamide, Hydroxypropylammonium Gluconate, Bis-Ethyl(Isostearylimidazoline) Isostearamide, Acrylates Copolymer, Glycol Distearate, Hydroxypropyl Guar Hydroxypropyltrimonium Chloride, Benzyl Alcohol, Fragrance (Parfum), Linalool, Eugenol, Geraniol, Amyl Cinnamal, Benzyl Salicylate, Citronellol, Hydroxycitronellal, Citral, Benzyl Benzoate, Limonene, Sodium Hydroxide, Tartaric Acid, Citric Acid, Sodium Phytate, Sodium Benzoate, Potassium Sorbate, Phenoxyethanol <ILN47712> Please be aware that ingredient lists may change or vary from time to time. Please refer to the ingredient list on the product package you receive for the most up to date list of ingredients.",
            category = categoryDao.GetByName("Cosmetics").Result
        };
        await context.Products.AddAsync(toCreate60);
        await context.SaveChangesAsync();



        return "Ok";
    }

    public async Task<Product> CreateAsync(Product product)
    {
        EntityEntry<Product> newProduct = await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        return newProduct.Entity;
    }
    

    public async Task<IEnumerable<Product>> GetAsync(SearchProductsParametersDto searchProductsParametersDto)
    {
        IQueryable<Product> query = context.Products.Include(product => product.category).AsQueryable();
    
        if (searchProductsParametersDto.nameContains != null)
        {
            query = query.Where(p =>
                p.name.ToLower().Contains(searchProductsParametersDto.nameContains.ToLower()));
        }
        
        IEnumerable<Product> result = await query.ToListAsync();
        return result;
    }

    public async Task<Product?> GetByIdAsync(long id)
    {
        Product? found = await context.Products
            .Include(product => product.category)
            .SingleOrDefaultAsync(product => product.id == id);
       //     .AsNoTracking().FirstOrDefaultAsync(p => p.id == id);

        return found;
    }

    public async Task UpdateAsync(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync(); 
    }

    public async  Task<Product?> GetByIdToUpdateAsync(long? id)
    {
        Product? found = await context.Products
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.id == id);

        return found;
    }
    
    public async Task<Product?> GetByIdToUpdateAsyncWithCategory(long? id)
    {
        Product? found = await context.Products
            .Include(product => product.category)
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.id == id);

        return found;
    }

    public async Task<Product?> GetSearchAsync(string? search)
    {
        Product?  existing = await context.Products.FirstOrDefaultAsync(p =>
            p.name.ToLower().Equals(search.ToLower())
        );
        return existing;
    }

    public async Task DeleteAsync(long id)
    {
        Product? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"Product with id {id} not found");
        }

        context.Products.Remove(existing);
        await context.SaveChangesAsync();    
    }

    public async Task AdminUpdateAsync(Product product)
    {
        ProductResponse productGrpc = await ClientProduct.EditProductAsync(new ProductGrpc()
        {
            Id = product.id,
            Name = product.name,
            Description = product.description,
            Category = new CategoryGrpc()
            {
                Name = product.category.ToString()
            },
            Price = product.price
            
        });
        
        
        context.Products.Update(product);
        await context.SaveChangesAsync();    
    }

    public async Task<String> CreateAdminOrderAsync(Product product)
    {
        ProductResponse productResponse = new ProductResponse();
        try
        {
            productResponse = await ClientProduct.OrderProductAsync(new ProductGrpc()
            {
                Id = product.id,
                Name = product.name,
                Description = product.description,
                Price = product.price,
                Category = new CategoryGrpc()
                {
                    Name = product.category.ToString()
                }
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return productResponse.Confirmed;
    }
}