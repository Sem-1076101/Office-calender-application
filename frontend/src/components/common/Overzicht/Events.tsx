import '/src/components/common/Overzicht/Events.scss';

interface Evenement {
  id: number;
  name: string;
}

const evenementen: Evenement[] = [
  { id: 1, name: "evenement" },
  { id: 2, name: "evenement" },
  { id: 3, name: "evenement" },
  { id: 4, name: "evenement" },
  { id: 5, name: "evenement" },
  { id: 6, name: "evenement" },
  { id: 7, name: "evenement" },
  { id: 8, name: "evenement" },
  { id: 9, name: "evenement" },
];

const Events = () => {
  return (
    <div>
      <header>
        <h1 className="table-title">Upcoming Events</h1>
      </header>

      <div className="table-wrapper">
        {evenementen.map(({ id, name }) => (
          <div key={id} className="event-card">
            <h1 className="event-id">{id}</h1>
            <h2 className="event-name">{name}</h2>
            <div className="event-details">
              <button>Details</button>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Events;
