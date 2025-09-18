import '/src/components/common/Overzicht/Events.scss';
import { useNavigate } from 'react-router-dom';
import { useEffect } from 'react';
interface Evenement {
  id?: number;
  name?: string;
  description?: string;
  date: string;
  place: string;

}

const evenementen: Evenement[] = [
  { id: 1, name: "evenement", description: "This is the description for event 1.", place: "rotterdam", date: "30/09/2025"},
  { id: 2, name: "evenement", description: "This is the description for event 2.", place: "online", date: "30/09/2025"},
  { id: 3, name: "evenement", description: "This is the description for event 3.", place: "online", date: "30/09/2025"},
  { id: 4, name: "evenement", description: "This is the description for event 4.", place: "online", date: "30/09/2025"},
  { id: 5, name: "evenement", description: "This is the description for event 5.", place: "online", date: "30/09/2025"},
  { id: 6, name: "evenement", description: "This is the description for event 6.", place: "online", date: "30/09/2025"},
  { id: 7, name: "evenement", description: "This is the description for event 7.", place: "online", date: "30/09/2025"},
  { id: 8, name: "evenement", description: "This is the description for event 8.", place: "online", date: "30/09/2025"},
  { id: 9, name: "evenement", description: "This is the description for event 9.", place: "online", date: "30/09/2025"}
];

const Events = () => {
  useEffect(() => {
          window.scrollTo(700, 700);
      });
  const navigate = useNavigate();
  const makePage = (id: number) => {
    console.log("Make page for event", id);
  };

  return (
    <div>
      <header>
        <h1 className="table-title">Upcoming Events</h1>
      </header>

      <div className="table-wrapper">
        {evenementen.map(({ id, name, place, date}) => (
          <div key={id} className="event-card">
            <h1 className="event-id">{id}</h1>
            <h2 className="event-name">{name}</h2>
            <div className="event-details">
              <button onClick={() => {navigate(`/events/${id}`); makePage(id);}}>Details</button>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Events;
