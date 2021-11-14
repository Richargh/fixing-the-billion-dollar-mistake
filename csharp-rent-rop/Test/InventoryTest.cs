using System.Linq;
using FluentAssertions;
using Richargh.BillionDollar.Classic;
using Xunit;
using static Richargh.BillionDollar.Classic.NotebookServiceStatus;
using static Richargh.BillionDollar.Classic.NotebookType;

namespace Richargh.BillionDollar.Test
{
    public class InventoryTest
    {
        [Fact(DisplayName="Should find nothing when Repository is empty")]
        public void ShouldFindNothing()
        {
            // given
            var testee = new Inventory();
            // when
            var result = testee.FindNotebookById(new NotebookId("1"));
            // then
            result.Should().BeNull();
        }
        
        [Fact(DisplayName="Should find notebook after we've put it into the Repository")]
        public void ShouldFindNotebookAfterPut()
        {
            // given
            var notebook = new Notebook(
                new NotebookId("1"), Performance, "Bell", "GT Banana", new Money(1_000), Available);
            var testee = new Inventory();
            testee.Store(notebook);
            // when
            var result = testee.FindNotebookById(notebook.Id);
            // then
            result.Should().BeEquivalentTo(notebook);
        }
        
        [Fact(DisplayName="Should find employee when already in the Repository")]
        public void ShouldFindAlreadyKnownNotebook()
        {
            // given
            var notebook = new Notebook(
                new NotebookId("1"), Performance, "Bell", "GT Banana", new Money(1_000), Available);
            var testee = new Inventory(notebook);
            // when
            var result = testee.FindNotebookById(notebook.Id);
            // then
            result.Should().BeEquivalentTo(notebook);
        }
        
        [Fact(DisplayName="Should find notebook by its type")]
        public void ShouldFindNotebookByType()
        {
            // given
            var performance = new Notebook(
                new NotebookId("1"), Performance, "Bell", "GT Banana", new Money(1_000), Available);
            var office = new Notebook(
                new NotebookId("2"), Office, "Bell", "M Cherry", new Money(500), Available);
            var testee = new Inventory();
            testee.Store(performance);
            testee.Store(office);
            // when
            var result = testee.FindNotebooksByType(Performance);
            // then
            result.Single().Should().BeEquivalentTo(performance);
        }
    }
}