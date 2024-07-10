import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-carousel',
  templateUrl: './product-carousel.component.html',
  styleUrls: ['./product-carousel.component.css'],
})
export class ProductCarouselComponent implements OnInit {
  @Input() cards :any;

 

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

  nextSlide(): void {
    this.currentIndex = (this.currentIndex + 1) % this.cards.length;
  }

  goToSlide(index: number): void {
    this.currentIndex = index;
  }
}
