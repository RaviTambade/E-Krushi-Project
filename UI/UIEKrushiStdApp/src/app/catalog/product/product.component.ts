import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  price: number = 100;
  searchString: string | null = null;

  constructor(private router: Router, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.searchString = params.get('input');
      if (this.searchString != null) {
        this.products = this.filterProducts(this.searchString);
      }
    });
  }
  products: any[] = [
    {
      imageUrl: '/assets/mira.webp',
      size: '250 gm',
      price: 100,
      title: 'Admire',
    },
    {
      imageUrl: '/assets/Rogor.jpeg',
      size: '250 gm',
      price: 480,
      title: 'ROGOR',
    },
    {
      imageUrl: '/assets/UREA.png',
      size: '250 gm',
      price: 45,
      title: 'UREA',
    },

    {
      imageUrl: '/assets/antracol.jpeg',
      size: '250 gm',
      price: 145,
      title: 'ANTARCOL',
    },
    {
      imageUrl: '/assets/Avtar.jpeg',
      size: '250 gm',
      price: 115,
      title: 'AVTAR',
    },
    {
      imageUrl: '/assets/coragen.jpeg',
      size: '250 gm',
      price: 110,
      title: 'CORAGEN',
    },
    {
      imageUrl: '/assets/zyme.jpeg',
      size: '250 gm',
      price: 450,
      title: 'ZYME',
    },
    {
      imageUrl: '/assets/Melody.jpeg',
      size: '250 gm',
      price: 550,
      title: 'MELODY',
    },
    {
      imageUrl: '/assets/10-26-26.jpeg',
      size: '250 gm',
      price: 400,
      title: '10-26-26',
    },
    {
      imageUrl: '/assets/12-32-16.jpeg',
      size: '250 gm',
      price: 600,
      title: '12-32-16',
    },
    {
      imageUrl: '/assets/Goal.jpeg',
      size: '250 gm',
      price: 200,
      title: 'GOAL',
    },

    {
      imageUrl: '/assets/targa-super.png',
      size: '250 gm',
      price: 500,
      title: 'TARGA SUPER',
    },
  ];

  filterProducts(searchString: string) {
    var products = this.products.filter((p) => p.title == searchString);
    return products;
  }
}
