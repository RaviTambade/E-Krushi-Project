import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {


  constructor(private router: Router) {}
  ngOnInit(): void {
  }
  products: any = [
    {
      imageUrl: '/assets/mira.webp',
      size: '250 gm',
      price: 100,
      title: 'Admire',
      rating:3.5
    },
    {
      imageUrl: '/assets/Rogor.jpeg',
      size: '250 gm',
      price: 480,
      title: 'ROGOR',
      rating:4.5

    },
    {
      imageUrl: '/assets/UREA.png',
      size: '250 gm',
      price: 45,
      title: 'UREA',
      rating:3

    },

    {
      imageUrl: '/assets/antracol.jpeg',
      size: '250 gm',
      price: 145,
      title: 'ANTARCOL',
      rating:3.5

    },
    {
      imageUrl: '/assets/Avtar.jpeg',
      size: '250 gm',
      price: 115,
      title: 'AVTAR',
      rating:2.5

    },
    {
      imageUrl: '/assets/coragen.jpeg',
      size: '250 gm',
      price: 110,
      title: 'CORAGEN',
      rating:4

    },
    {
      imageUrl: '/assets/zyme.jpeg',
      size: '250 gm',
      price: 450,
      title: 'ZYME',
      rating:3.5

    },
    {
      imageUrl: '/assets/Melody.jpeg',
      size: '250 gm',
      price: 550,
      title: 'MELODY',
      rating:3.5

    },
    {
      imageUrl: '/assets/10-26-26.jpeg',
      size: '250 gm',
      price: 400,
      title: '10-26-26',
      rating:3.5

    },
    {
      imageUrl: '/assets/12-32-16.jpeg',
      size: '250 gm',
      price: 600,
      title: '12-32-16',
      rating:3.5

    },
    {
      imageUrl: '/assets/Goal.jpeg',
      size: '250 gm',
      price: 200,
      title: 'GOAL',
      rating:3.5

    },

    {
      imageUrl: '/assets/targa-super.png',
      size: '250 gm',
      price: 500,
      title: 'TARGA SUPER',
      rating:3.5

    },
  ];
}
