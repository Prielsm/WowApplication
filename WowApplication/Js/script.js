import '../styles.scss';

import '../styles/donjons.scss';
import '../styles/loot.scss';

import { applyDonjonsView } from './views/donjons';
import { applyLootView } from './views/loot';

document.body.addEventListener('click', (e) => {
  if (e.target.matches('.retour-accueil')) {
    document.body.innerHTML = `<header>
    <div class="big_word one">World</div>
    <div class="small_word">of</div>
    <div class="big_word two">Warcraft</div>
  </header>  
  <main class="main-index">
    <div><img class="donjons-view" src="images/citadelle_couronne_glace.jpg" alt=""></div>
  </main>
  `;
    document.body.className = 'body-index';
  }

  if (e.target.matches('.donjons-view')) {
    console.log('c est encore moi');
    applyDonjonsView();
  }

  if (e.target.matches('.donjon')) {
    applyLootView();
  }

  if (e.target.matches('.retour-donjons')) {
    applyDonjonsView();
  }

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
    const btnFilter = document.querySelector('.btn-filter');
    const djName = document.querySelector('.donjon-name');
    if (filters.classList.contains('d-none')) {
      filters.classList.remove('d-none');
      btnFilter.innerHTML = `<img src="svg/filter_full.svg" alt="" />
      <span class="filtrer">Filtrer</span>`;
      djName.classList.add('d-none');
    } else {
      filters.classList.add('d-none');
      btnFilter.innerHTML = `<img src="svg/filter.svg" alt="" />
      <span class="filtrer">Filtrer</span>`;
      djName.classList.remove('d-none');
    }
  }
});
