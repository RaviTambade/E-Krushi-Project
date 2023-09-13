import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-carousel',
  templateUrl: './product-carousel.component.html',
  styleUrls: ['./product-carousel.component.css']
})
export class ProductCarouselComponent implements OnInit {
  cards = [
    {
      imageUrl: '/assets/Pesticides.png',
    },
    {
      imageUrl: '/assets/antracolmain1.jpg',
    },
    {
      imageUrl: '/assets/tools.png',
    },
  ];

  currentIndex = 0;

  constructor() {}
  ngOnInit(): void {
    this.startCarousel();
  }

  startCarousel(): void {
    setInterval(() => {
      this.nextSlide();
    }, 3000); 
  }

  prevSlide(): void {
    this.currentIndex = (this.currentIndex - 1 + this.cards.length) % this.cards.length;
  }

  nextSlide(): void {
    this.currentIndex = (this.currentIndex + 1) % this.cards.length;
  }

  goToSlide(index: number): void {
    this.currentIndex = index;
  }



}
