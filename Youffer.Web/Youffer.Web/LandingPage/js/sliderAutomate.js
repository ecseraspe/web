var next = 2;
var previous = 1;
var sliderInterval;
var timeInterval = 5000;

function setSliderInMotion() {
	sliderInterval = setInterval(function(){
	var length = $('.wallop-slider__list').children().length;
	var currentClass = 'wallop-slider__item--current';
	var prevClass = 'wallop-slider__item--hide-previous';
	var nextClass = 'wallop-slider__item--show-next';
	$('.wallop-slider__list li').removeClass(prevClass);
	$('.wallop-slider__list li:nth-child('+previous+')').removeClass(currentClass);
	$('.wallop-slider__list li:nth-child('+previous+')').removeClass(nextClass);
	$('.wallop-slider__list li:nth-child('+previous+')').addClass(prevClass);
	$('.wallop-slider__list li:nth-child('+next+')').addClass(currentClass);
	$('.wallop-slider__list li:nth-child('+next+')').addClass(nextClass);
	if(next==length) {
		next = 1;
		previous = length;
	}
	else {
		previous = next;
		next = next + 1;
	}
},timeInterval);
}

function showNext()
{
	clearInterval(sliderInterval);
	var length = $('.wallop-slider__list').children().length;
	var currentClass = 'wallop-slider__item--current';
	var prevClass = 'wallop-slider__item--hide-previous';
	var nextClass = 'wallop-slider__item--show-next';
	var altPrevClass = 'wallop-slider__item--hide-next';
	var altNextClass = 'wallop-slider__item--show-previous';
	$('.wallop-slider__list li').removeClass(prevClass);
	$('.wallop-slider__list li').removeClass(altPrevClass);
	$('.wallop-slider__list li').removeClass(altNextClass);
	$('.wallop-slider__list li:nth-child('+previous+')').removeClass(currentClass);
	$('.wallop-slider__list li:nth-child('+previous+')').removeClass(nextClass);
	$('.wallop-slider__list li:nth-child('+previous+')').addClass(prevClass);
	$('.wallop-slider__list li:nth-child('+next+')').addClass(currentClass);
	$('.wallop-slider__list li:nth-child('+next+')').addClass(nextClass);
	if(next>=length) {
		next = 1;
		previous = length;
	}
	else {
		previous = next;
		next = next + 1;
	}
	setSliderInMotion();
}

function showPrev()
{
	clearInterval(sliderInterval);
	var length = $('.wallop-slider__list').children().length;
	next = previous;
	if(next==1) {
		next = length;
		previous = 1;
		console.log('true');
	}
	else {
		previous = next;
		next = next - 1;
		console.log('false');
	}
	var currentClass = 'wallop-slider__item--current';
	var prevClass = 'wallop-slider__item--hide-next';
	var nextClass = 'wallop-slider__item--show-previous';
	var altPrevClass = 'wallop-slider__item--hide-previous';
	var altNextClass = 'wallop-slider__item--show-next';
	$('.wallop-slider__list li').removeClass(prevClass);
	$('.wallop-slider__list li').removeClass(altPrevClass);
	$('.wallop-slider__list li').removeClass(altNextClass);
	$('.wallop-slider__list li').removeClass(currentClass);
	$('.wallop-slider__list li').removeClass(nextClass);
	$('.wallop-slider__list li:nth-child('+previous+')').addClass(prevClass);
	$('.wallop-slider__list li:nth-child('+next+')').addClass(currentClass);
	$('.wallop-slider__list li:nth-child('+next+')').addClass(nextClass);
	previous = next;
	next = next + 1;
	setSliderInMotion();
}

$(document).ready(function(){
	setSliderInMotion();
});