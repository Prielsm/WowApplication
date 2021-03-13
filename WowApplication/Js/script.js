document.body.addEventListener('click', (e) => {

  if (e.target.matches('.connection') || e.target.matches('.span-connection') || e.target.matches('.icon-connection')) {
    const modal = document.querySelector('.modal');
    console.log('modal!');
    modal.classList.remove('d-none');
  }

  if (e.target.matches('.close')) {
    const modal = document.querySelector('.modal');
    console.log('modal!');
    modal.classList.add('d-none');
  }

  if (e.target.matches('.filtrer')) {
    console.log('filtrer');
      const filters = document.querySelector('.filters');
      console.log(filters.classList);
    const btnFilter = document.querySelector('.btn-filter');
    const djName = document.querySelector('.donjon-name');
    if (filters.classList.contains('d-none')) {
      filters.classList.remove('d-none');
        filters.classList.add('flex');
      btnFilter.innerHTML = `<img src="/Static/SVG/filter_full.svg" alt="" />
      <span class="filtrer">Filtrer</span>`;
      djName.classList.add('d-none');
    } else {
      filters.classList.add('d-none');
        filters.classList.remove('flex');
        btnFilter.innerHTML = `<img src="/Static/SVG/filter.svg" alt="" />
      <span class="filtrer">Filtrer</span>`;
      djName.classList.remove('d-none');
    }
  }
});
