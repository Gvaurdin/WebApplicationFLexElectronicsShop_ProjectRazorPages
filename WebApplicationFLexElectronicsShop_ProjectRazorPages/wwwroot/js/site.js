function updateHeaderHeight() {
    var headerHeight = document.querySelector('nav').offsetHeight;
    document.documentElement.style.setProperty('--header-height', headerHeight + 'px');
}

// Обновляем высоту хедера при загрузке страницы и при изменении размера окна
window.addEventListener('load', updateHeaderHeight);
window.addEventListener('resize', updateHeaderHeight);
