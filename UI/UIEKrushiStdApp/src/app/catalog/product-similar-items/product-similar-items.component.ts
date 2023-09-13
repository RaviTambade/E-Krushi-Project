import { Component } from '@angular/core';

type Product = {
  imageUrl: string;
  title: string;
  price: number;
};

@Component({
  selector: 'app-product-similar-items',
  templateUrl: './product-similar-items.component.html',
  styleUrls: ['./product-similar-items.component.css'],
})
export class ProductSimilarItemsComponent {
  products: Product[] = [
    {
      imageUrl: '/assets/mira.webp',
      price: 100,
      title: 'Admire',
    },
    {
      imageUrl: '/assets/Rogor.jpeg',
      price: 480,
      title: 'ROGOR',
    },
    {
      imageUrl: '/assets/UREA.png',
      price: 45,
      title: 'UREA',
    },

    {
      imageUrl: '/assets/antracol.jpeg',
      price: 145,
      title: 'ANTARCOL',
    },
    {
      imageUrl: '/assets/Avtar.jpeg',
      price: 115,
      title: 'AVTAR',
    },
    {
      imageUrl: '/assets/coragen.jpeg',
      price: 110,
      title: 'CORAGEN',
    },
    {
      imageUrl: '/assets/zyme.jpeg',
      price: 450,
      title: 'ZYME',
    },
    {
      imageUrl: '/assets/Melody.jpeg',
      price: 550,
      title: 'MELODY',
    },
    {
      imageUrl: '/assets/10-26-26.jpeg',
      price: 400,
      title: '10-26-26',
    },
    {
      imageUrl: '/assets/12-32-16.jpeg',
      price: 600,
      title: '12-32-16',
    },
    {
      imageUrl: '/assets/Goal.jpeg',
      price: 200,
      title: 'GOAL',
    },

    {
      imageUrl: '/assets/targa-super.png',
      price: 500,
      title: 'TARGA SUPER',
    },
  ];
}
