document.body.addEventListener('click', (e) => {

  if (e.target.matches('.filtrer')) {
    console.log('filtrer');
      const filters = document.querySelector('.filters');
      console.log(filters.classList);
    const btnFilter = document.querySelector('.btn-filter');
    if (filters.classList.contains('d-none')) {
      filters.classList.remove('d-none');
        filters.classList.add('flex');
      btnFilter.innerHTML = `<img src="/Static/SVG/filter_full.svg" alt="" />
      <span class="filtrer">Filtrer</span>`;
    } else {
      filters.classList.add('d-none');
        filters.classList.remove('flex');
        btnFilter.innerHTML = `<img src="/Static/SVG/filter.svg" alt="" />
      <span class="filtrer">Filtrer</span>`;
    }
  }
});
